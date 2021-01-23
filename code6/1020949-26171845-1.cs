    [assembly: OwinStartup(typeof(CRMWeb.Startup))]
    
    namespace CRMWeb
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR();
            }
        }
    }
