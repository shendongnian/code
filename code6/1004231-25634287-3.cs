    public void Configuration(IAppBuilder app)
    {
        GlobalHost.DependencyResolver = new DefaultDependencyResolver();
        // GlobalHost.ConnectionManager now references the one provided by
        // the DefaultDependencyResolver instantiated in the line above.
        var myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        // SignalR will use GlobalHost.DependencyResolver by default
        app.MapSignalR();
    }
