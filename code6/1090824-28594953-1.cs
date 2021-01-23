                var builder= new ContainerBuilder();
                builder.RegisterType<ComponentFactory>();
                builder.RegisterType<Component>();
                builder.RegisterType<Dependency>();
    
                var container = builder.Build();
                var factory = container.Resolve<ComponentFactory>();
                
                //Usage with typed parameters
                var component = factory.Create(new Dependency());
