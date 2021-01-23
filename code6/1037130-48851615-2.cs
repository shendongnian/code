    [assembly: OwinStartup(typeof(MyAPI.Startup))]
    namespace MyAPI
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                // DI etc
                // ...
                GlobalConfiguration.Configure(ODataConfig.Register); // 1st
                GlobalConfiguration.Configure(WebApiConfig.Register); // 2nd      
                // ... filters, routes, bundles etc
                GlobalConfiguration.Configuration.EnsureInitialized();
            }
        }
    }
