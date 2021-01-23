    container.RegisterManyForOpenGeneric(typeof(ICommandHandler<,>), myAssemblies);
    container.RegisterDecorator(typeof(ICommandHandler<,>), 
        typeof(TransactionDecorator<,>), 
        c => typeof(ITransactionalCommandHandler<,>)
                .MakeGenericType(c.ServiceType.GetGenericArguments())
                    .IsAssignableFrom(c.ImplementationType));
    container.RegisterDecorator(typeof(ICommandHandler<,>), 
        typeof(AuthorisationDecorator<,>));
