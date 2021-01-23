    using System;
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Owin;
    
    [assembly: OwinStartup(typeof(UserInterfaceLayer.Hubs.Startup))]
    
    namespace UserInterfaceLayer.Hubs
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR();
            }
        }
    }
