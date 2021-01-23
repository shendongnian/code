    public void Configuration(IAppBuilder app)
    {
        var resolver = new DefaultDependencyResolver();
        var connectionManager = resolver.Resolve<IConnectionManager>();
        var myHubContext = connectionManager.GetHubContext<MyHub>();
        app.MapSignalR(new HubConfiguration
        {
            Resolver = resolver
        });
    }
