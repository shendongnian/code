    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
        
            // register your services here...
            // replace...
            /* GlobalConfiguration.Configuration.DependencyResolver = new      Unity.WebApi.UnityDependencyResolver(container); */
            // with this:
            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
