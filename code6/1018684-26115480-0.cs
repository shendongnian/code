    public void Configure(IAppBuilder app)
    {
        var resolver = new MyStructureMapResolver();
        // configure depdendency resolver
        GlobalHost.DependencyResolver = this.container.Resolve<IDependencyResolver>();
        // map the hubs
        app.MapSignalR();
        // get your hub context
        var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        
        // register it in your structure map
        ObjectFactory.Inject<IHubContext>(hubContext);
    }    
