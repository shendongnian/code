    container.RegisterManyForOpenGeneric(
        typeof(ICommandHandler<>),
        Assembly.GetExecutingAssembly());
    container.RegisterManyForOpenGeneric(
        typeof(IEventHandler<>),
        container.RegisterAll,
        Assembly.GetExecutingAssembly());
