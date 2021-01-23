        public static void RegisterMessageHandlers(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var eventListeners = assembly.GetTypes().Where(
                    t => t.IsClass &&
                         t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventListener<>)));
                foreach (var eventListener in eventListeners)
                {
                    var interfaces = eventListener.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventListener<>));
                    
                    foreach (var @interface in interfaces)
                    {
                        var eventType = @interface.GetGenericArguments()[0];
                        builder.RegisterType(eventListener)
                            .As<IEventListener>()
                            .WithMetadata<EventListenerMetadata>(c => c.For(m => m.EventType, eventType));
                    }
                }
            }
        }
