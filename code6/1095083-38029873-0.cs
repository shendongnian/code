        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
           .As(type => type.GetInterfaces()
               .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<,>)))
               .Select(interfaceType => new KeyedService("commandHandler", interfaceType)))
           .InstancePerLifetimeScope();
