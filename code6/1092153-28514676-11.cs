    // Simple Injector v3.x
    container.RegisterCollection(typeof(IValidator<>), _assemblies);
    // Simple Injector v2.x
    container.RegisterManyForOpenGeneric(typeof(IValidator<>),
        container.RegisterAll, _assemblies);
