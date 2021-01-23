    using Hangfire;
    using Hangfire.SqlServer;
    using Hangfire.Dashboard;
    
    public class Startup
    {
    	public void Configuration(IAppBuilder app)
            {
                app.UseHangfire(config =>
                {
                    config.UseSqlServerStorage("Data Source=<connectionstring>; Initial Catalog=HangFire; Trusted_Connection=true;");
                    config.UseServer();
    
                    //config.UseAuthorizationFilters(new AuthorizationFilter
                    //{
                    //    // Users = "admin, superuser", // allow only specified users
                    //    Roles = "admins" // allow only specified roles
                    //});
                });
    	}
    }
