    Func<IUnitOfWork> uowFactory = 
        () => new MyUnitOfWork(connectionString);
    // Register the factory as Lazy<IUnitOfWork>
    container.Register<Lazy<IUnitOfWork>>(
        () => new Lazy<IUnitOfWork>(uowFactory), 
        Lifestyle.Scoped);
    // Register the proxy that delays the creation of the UoW
    container.Register<IUnitOfWork, DelayedUnitOfWorkProxy>(
        Lifestyle.Scoped);
