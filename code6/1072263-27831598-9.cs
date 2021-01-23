    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            
            // Add Identity services to the services container.
            services.AddDefaultIdentity<ApplicationIdentityDbContext, ApplicationUser, IdentityRole>(Configuration,
                o => {
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonLetterOrDigit = false;
                    o.Password.RequiredLength = 7;
                });
        }
    }
