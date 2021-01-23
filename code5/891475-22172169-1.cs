    [assembly: OwinStartup(typeof(Startup))]
    namespace MvcProject.App_Start
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var hubConfiguration = new HubConfiguration();
    
    #if DEBUG
                hubConfiguration.EnableDetailedErrors = true;
    #endif
                app.MapSignalR(hubConfiguration);
