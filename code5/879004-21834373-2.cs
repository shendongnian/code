    public static class ApplicationContainer
    {
      public static IContainer Container { get; set; }
    }
    // And then when you build your resolvers...
    var container = builder.Build();
    GlobalConfiguration.Configuration.DependencyResolver =
      new AutofacWebApiDependencyResolver(container);
    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    ApplicationContainer.Container = container;
