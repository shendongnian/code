    // Create some "holder" for the app container.
    public static class ApplicationContainerProvider
    {
      public static ILifetimeScope Container { get; set; }
    }
    // In Global.asax, build your container and set it in both
    // the DependencyResolver AND in the holder class.
    var builder = new ContainerBuilder();
    builder.RegisterType<Something>().As<ISomething>();
    var container = builder.Build();
    var resolver = new AutofacDependencyResolver(container);
    DependencyResolver.SetResolver(resolver);
    ApplicationContainerProvider.Container = container;
    // In your service location, reference the container instead of
    // DependencyResolver.
    public class SqlResourceProviderFactory : ResourceProviderFactory
    {
      public IServiceManager ServiceManager { get; set; }
      public SqlResourceProviderFactory()
      {
        this.ServiceManager =
          ApplicationContainerProvider.Container.Resolve<IServiceManager>();
      }
    }
