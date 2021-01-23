    // Ninject
    kernel.Bind<IDatabase>().To<DatabaseDispatcher>();
    // Unity
    container.RegisterType<IDatabase, DatabaseDispatcher>();
    // Simple Injector
    container.Register<IDatabase, DatabaseDispatcher>();
