    using System;
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Owin;
    
    [assembly: OwinStartup(typeof(SignalRWebRTCExample.Startup))]
    
    namespace SignalRWebRTCExample
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR();
            }
        }
    }
