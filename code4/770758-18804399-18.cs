    container.Options.DefaultScopedLifestyle = Lifestyle.CreateHybrid(
        () => container.GetCurrentLifetimeScope() != null,
        new LifetimeScopeLifestyle(),
        new WebRequestLifestyle());
    
    Func<IUnitOfWork> uowFactory = 
        () => new MyUnitOfWork(connectionString);
    // Register the factory as Lazy<IUnitOfWork>
    container.Register<Lazy<IUnitOfWork>>(
        () => new Lazy<IUnitOfWork>(uowFactory), 
        Lifestyle.Scoped);
    // Register a proxy that depends on Lazy<IUnitOfWork>    
    container.Register<IUnitOfWork, DelayedUnitOfWorkProxy>(
        Lifestyle.Scoped);
