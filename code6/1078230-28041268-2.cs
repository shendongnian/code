    // Autofac
    builder.Register<IPcSubsContextProvider>(c =>
        new LazyPcSubsContextProvider(() =>
            new PCSubsDBContext(GetConnectionStringForCurrentRequest())))
       .InstancePerHttpRequest();
    // Ninject
    kernel.Bind<IPcSubsContextProvider>().ToMethod(m =>
        new LazyPcSubsContextProvider(() =>
            new PCSubsDBContext(GetConnectionStringForCurrentRequest())))
        .InRequestScope();
    // Simple Injector
    container.RegisterPerWebRequest<IPcSubsContextProvider>(() =>
        new LazyPcSubsContextProvider(() =>
            new PCSubsDBContext(GetConnectionStringForCurrentRequest())));
