    var assemblies = new[]
    {
        typeof(SomeQueryHandlerImplementation).Assembly,
        typeof(SqlRepository<>).Assembly,
    };
    // Simple Injector v3.x
    _container.Register(typeof(ICommandHandler<>), assemblies);
    _container.Register(typeof(ICommandHandler<,>), assemblies);
    _container.Register(typeof(IValidator<>), assemblies);
    _container.Register(typeof(IQueryHandler<,>), assemblies);
    // Simple Injector v2.x
    _container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), assemblies);
    _container.RegisterManyForOpenGeneric(typeof(ICommandHandler<,>), assemblies);
    _container.RegisterManyForOpenGeneric(typeof(IValidator<>), assemblies);
    _container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), assemblies);
