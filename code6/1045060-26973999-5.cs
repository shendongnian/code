        public TestSelector()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MessageAHandler>().As<IMessageHandler<MessageA>>();
            containerBuilder.RegisterType<MessageBHandler>().As<IMessageHandler<MessageB>>();
            containerBuilder.RegisterType<MessageHandlerAdapter<MessageA>>().As<IMessageHandler>();
            containerBuilder.RegisterType<MessageHandlerAdapter<MessageB>>().As<IMessageHandler>();
            containerBuilder.RegisterType<MessageReceiver>();
            this.container = containerBuilder.Build();
        }
