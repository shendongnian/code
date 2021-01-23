    IUnityContainer rootContainer = new UnityContainer();
    GlobalConfiguration.Configuration.DependencyResolver =
        new UnityHierarchicalDependencyResolver(rootContainer);
    rootContainer.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>
        (new HierarchicalLifetimeManager());
