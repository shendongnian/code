    // Autofac
    builder.Register<PCSubsDBContext>(c =>
        new PCSubsDBContext(GetConnectionStringForCurrentRequest());
    // Ninject
    kernel.Bind<PCSubsDBContext>().ToMethod(m =>
        new PCSubsDBContext(GetConnectionStringForCurrentRequest());
    // Simple Injector
    container.Register<PCSubsDBContext>(() =>
        new PCSubsDBContext(GetConnectionStringForCurrentRequest());
