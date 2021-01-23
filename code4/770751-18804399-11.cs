    var scopedLifestyle = Lifestyle.CreateHybrid(
        () => container.GetCurrentLifetimeScope() != null,
        new LifetimeScopeLifestyle(),
        new WebRequestLifestyle());
    
    Func<IUnitOfWork> uowFactory = 
        () => new MyUnitOfWork(connectionString);
    // Register the factory as Lazy<IUnitOfWork>
    container.Register<Lazy<IUnitOfWork>>(
        () => new Lazy<IUnitOfWork>(uowFactory), 
        scopedLifestyle); // use scoped lifestyle here
    // Register a proxy that depends on Lazy<IUnitOfWork>    
    container.Register<IUnitOfWork, DelayedUnitOfWorkProxy>(
        scopedLifestyle); // and here
