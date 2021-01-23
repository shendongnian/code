    public static class Startup
    {
      public static void Configuration(IAppBuilder app)
      {
        var container = DependencyConfiguration.Configure(app);
        SignalRConfiguration.Configure(app, container);
        MvcConfiguration.Configure(app, container);
      }
    }
    public static class DependencyConfiguration
    {
      public static IContainer Configure(IAppBuilder app)
      {
        var builder = new ContainerBuilder();
        builder.RegisterHubs(typeof(SignalRConfiguration).Assembly);
        var container = builder.Build();
        app.UseAutofacMiddleware(container);
        return container;
      }
    }
    public static class SignalRConfiguration
    {
      public static void Configure(IAppBuilder app, IContainer container)
      {
        var config = new HubConfiguration();
        config.Resolver = new AutofacDependencyResolver(container);
        app.MapSignalR("/signalr", config);
      }
    }
