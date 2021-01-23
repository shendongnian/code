    using Owin;
    using Hangfire;
    using Hangfire.Dashboard;
    
    public class OWINStartup
    {
        public void Configuration(IAppBuilder app)
        {        
            GlobalConfiguration.Configuration.UseSqlServerStorage("String");
            DashboardOptions options = new DashboardOptions()
            {
                AuthorizationFilters = new IAuthorizationFilter[]
                {
                    new MyRestrictiveAuthorizationFilter()
                }
            };
            app.UseHangfireDashboard("/hangfire", options);
        }
    }
