    public void Configuration(IAppBuilder app)
    {
        .... Other configurations ....
        GlobalHost.DependencyResolver = new DefaultDependencyResolver();
        app.MapSignalR();
    }
