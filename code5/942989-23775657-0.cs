    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration {Resolver = new DefaultDependencyResolver()};
            app.MapSignalR(hubConfiguration);
        }
    }
