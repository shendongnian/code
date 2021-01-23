    container.RegisterDecorator(typeof(IMessageHandler<>),
        typeof(MessageLogDecorator<>), context =>
        {
            var type = context.ImplementationType;
            return !type.IsGenericType ||
                type.GetGenericTypeDefinition() != typeof(CompositeMessageHandler<>));
        });
