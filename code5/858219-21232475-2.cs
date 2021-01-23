    // NOTE: In Simple Injector v2.x use 'ManyForOpenGeneric' instead.
    container.Register(typeof(ICommandHandler<,>), myAssemblies);
    container.RegisterDecorator(typeof(ICommandHandler<,>), typeof(TransactionDecorator<,>), 
        c => typeof(ITransactionalCommandHandler<,>)
                .MakeGenericType(c.ServiceType.GetGenericArguments())
                    .IsAssignableFrom(c.ImplementationType));
    container.RegisterDecorator(typeof(ICommandHandler<,>), typeof(AuthorisationDecorator<,>));
