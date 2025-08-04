using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
  {
    // Add services to the container.
    services.AddControllers();
    services.AddDbContext<DataContext>(opt =>{
    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
    });
    services.AddCors();
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IPhotoService, PhotoService>();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

    return services;
  }
}
