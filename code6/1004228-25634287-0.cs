    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin;
    using Owin;
    namespace SignalRSandbox
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR(new HubConfiguration
                {
                    Resolver = new DefaultDependencyResolver()
                });
            }
        }
    }
