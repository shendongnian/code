    builder.RegisterAssemblyTypes()
        .Where(t => t.GetInterfaces()
        .Any(i => i.IsGenericType && 
            i.GetGenericDefinition() = typeof(IRepository<>)))
        .AsImplementedInterfaces();
