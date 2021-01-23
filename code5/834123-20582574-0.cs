    [assembly: OwinStartupAttribute(typeof(YourNamespace.Startup))]
    namespace YourNamespace
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                //IoC container registration process
                UnityConfig.RegisterComponents();
    
                UnityConfig.Container.RegisterType<AHub, AHub>();
    
                HubConfiguration config = new HubConfiguration();
                config.EnableJavaScriptProxies = true;
                //You should remove your dependency resolver code from here to Global.asax Application_Start method. Before setting the MVC properties.
                //config.Resolver = new SignalrDefaultDependencyResolver(UnityConfig.Container); // your dependency resolver
                //
                app.MapSignalR(config);
            }
        }
    }
