    // Simple Injector v3.x
    container.RegisterCollection(typeof(INotificationHandler<>),
        AppDomain.CurrentDomain.GetAssemblies());
    // Simple Injector v2.x
    container.RegisterManyForOpenGeneric(
        typeof(INotificationHandler<>),
        container.RegisterAll,
        AppDomain.CurrentDomain.GetAssemblies());
