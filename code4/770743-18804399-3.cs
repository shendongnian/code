    Func<IUnitOfWork> uowFactory = 
        () => new MyUnitOfWork(connectionString);
    // Register the factory as Lazy<IUnitOfWork>
    container.Register<Lazy<IUnitOfWork>>(
        () => new Lazy<IUnitOfWork>(uowFactory), 
        new WebRequestLifestyle());
    // Register a proxy that depends on Lazy<IUnitOfWork>    
    container.Register<IUnitOfWork, UnitOfWorkProxy>(
        new WebRequestLifestyle());
