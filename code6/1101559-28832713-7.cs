        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterType<Pouet>().AsSelf();
        builder.RegisterType<Foo>().AsSelf();
        builder.RegisterType<Bar1>().As<IBar>();
        builder.RegisterType<Bar2>().As<IBar>();
        IContainer container = builder.Build();
        using (ILifetimeScope workScope = container.BeginLifetimeScope())
        {
            List<Pouet> pouets = new List<Pouet>();
            foreach (IComponentRegistration registration in container.ComponentRegistry.RegistrationsFor(new TypedService(typeof(IBar))))
            {
                using (ILifetimeScope scope = container.BeginLifetimeScope(cb => cb.RegisterComponent(registration)))
                {
                    Pouet pouet = scope.Resolve<Pouet>();
                    workScope.Disposer.AddInstanceForDisposal(scope);
                    pouets.Add(pouet);
                }
            }
            Console.WriteLine(pouets.Count);
        }
