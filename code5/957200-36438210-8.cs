    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        // Configure Unity
        var resolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
        GlobalConfiguration.Configuration.DependencyResolver = resolver;
        config.DependencyResolver = resolver;
        // Do Web API configuration
        WebApiConfig.Register(config);
        app.UseWebApi(config);
    }
