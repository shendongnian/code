    // Ninject
    kernel.Bind<IDatabase>().ToMethod(c => new DatabaseDispatcher(
        primaryStore: kernel.Get<SQLReposity>(),
        fallbackStore: kernel.Get<WFCReposity>(),
        persistentStore: kernel.Get<VistaDBReposity>()));
    // Unity
    container.Register<IDatabase>(new InjectionFactory(c => new DatabaseDispatcher(
        primaryStore: c.Resolve<SQLReposity>(),
        fallbackStore: c.Resolve<WFCReposity>(),
        persistentStore: c.Resolve<VistaDBReposity>())));
    // Simple Injector
    container.Register<IDatabase>(() => new DatabaseDispatcher(
        primaryStore: container.GetInstance<SQLReposity>(),
        fallbackStore: container.GetInstance<WFCReposity>(),
        persistentStore: container.GetInstance<VistaDBReposity>()));
