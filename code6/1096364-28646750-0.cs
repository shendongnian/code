        ContainerBuilder builder = new Autofac.ContainerBuilder();
        builder.RegisterType<A>().AsSelf();
        builder.RegisterType<B>().AsSelf();
        builder.RegisterType<C>().AsSelf();
        IContainer container = builder.Build();
        EventHandler<LifetimeScopeBeginningEventArgs> lifetimeScopeBeginning = null;
        lifetimeScopeBeginning = (sender, e) =>
        {
            e.LifetimeScope.ResolveOperationBeginning += (sender2, e2) =>
            {
                List<IInstanceActivator> activators = new List<IInstanceActivator>();
                e2.ResolveOperation.InstanceLookupBeginning += (sender3, e3) =>
                {
                    activators.Add(e3.InstanceLookup.ComponentRegistration.Activator);
                    Console.WriteLine("Activation Path : {0}", String.Join(" => ", activators.Select(a => a.LimitType.Name).ToArray()));
                };
            };
            e.LifetimeScope.ChildLifetimeScopeBeginning += lifetimeScopeBeginning;
        };
        container.ChildLifetimeScopeBeginning += lifetimeScopeBeginning;
        using (ILifetimeScope scope = container.BeginLifetimeScope())
        {
            scope.Resolve<C>();
        }
