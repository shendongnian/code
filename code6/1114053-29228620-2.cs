    public void Configuration(IAppBuilder app)
    {
        app.Map("/signalr", RegisterSignalR);
    }
    public static void RegisterSignalR(IAppBuilder map)
    {
       var resolver = new StructureMapSignalRDependencyResolver(IoC.Initialize());
       var config = new HubConfiguration { Resolver = resolver };
       map.UseCors(CorsOptions.AllowAll);
       map.RunSignalR(config);
    }
