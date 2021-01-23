    container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>),
        Assembly.GetExecutingAssembly());
    // This registers a collection of eventhandlers with RegisterAll,
    // since there can be multiple implementations for the same event.
    container.RegisterManyForOpenGeneric(typeof(IEventHandler<>),
        container.RegisterAll,
        Assembly.GetExecutingAssembly());
