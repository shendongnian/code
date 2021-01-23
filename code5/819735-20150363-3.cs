        IEnumerable<Type> handlers = types.Where(t => IsAssignableToGenericType(t, typeof(IDomainEventHandler<>)) && !t.IsInterface);
                        
        foreach (var handler in handlers)
        {
            container.AddNewExtension<OpenGenericExtension>()
                        .Configure<IOpenGenericExtension>()
                        .RegisterClosedImpl(typeof (IDomainEventHandler<>), handler);
        }
