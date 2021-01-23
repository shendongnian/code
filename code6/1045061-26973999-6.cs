        public TestSelector()
        {
            var containerBuilder = new ContainerBuilder();
            Func<Type, Type> GetHandlerInterface = (t) => t.GetInterfaces()
                .Where(iface => iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IMessageHandler<>)).FirstOrDefault();
            var handlerTypes = typeof(IMessage).Assembly.GetTypes()
                .Where(type => type.IsClass
                    && !type.IsAbstract
                    && GetHandlerInterface(type) != null);
            foreach (Type handlerType in handlerTypes)
            {
                Type messageType = GetHandlerInterface(handlerType).GetGenericArguments()[0];
                var genericHandler = typeof(MessageHandlerAdapter<>).MakeGenericType(messageType);
                containerBuilder.RegisterType(handlerType).AsImplementedInterfaces();
                containerBuilder.RegisterType(genericHandler).As<IMessageHandler>();
            }
            containerBuilder.RegisterType<MessageReceiver>();
            this.container = containerBuilder.Build();
        }
