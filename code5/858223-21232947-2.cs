    container.RegisterDecorator(
        typeof(ICommandHandler<,>),
        typeof(MockUnitOfWorkDecorator<,>),
        context =>
        {
            var baseType = typeof(ITransactionalCommandHandler<,>);
            var type = baseType.MakeGenericType(
                context.ServiceType.GetGenericArguments());
            return type.IsAssignableFrom(context.ImplementationType);
        });
