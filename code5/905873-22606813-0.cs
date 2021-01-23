    builder.RegisterAssemblyTypes(assemblies)
        .As(t => t.GetInterfaces()
        .Where(a => a.IsClosedTypeOf(typeof(ICommandHandler<>))));
    builder.RegisterAssemblyTypes(assemblies)
        .As(t => t.GetInterfaces()
        .Where(a => a.IsClosedTypeOf(typeof(IQueryHandler<>))));
    builder.RegisterAssemblyTypes(assemblies)
        .As(t => t.GetInterfaces()
        .Where(a => a.IsClosedTypeOf(typeof(IRepository<>))));
