    [assembly: OwinStartup("Configuration", typeof(StartUp))]
    namespace WebPipes
    {
        public class StartUp
        {
            public void Configuration(IAppBuilder app)
            {
                GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireDB");
    
                app.UseHangfireServer();
                app.UseHangfireDashboard();
            }
        }
    }
