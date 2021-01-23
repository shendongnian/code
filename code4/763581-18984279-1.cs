    WindsorContainer container = new WindsorContainer();
    container.Kernel.Resolver.AddSubResolver(
            new CollectionResolver(container.Kernel, true));
    container.Register(Types.FromThisAssembly()
            .BasedOn(typeof(IDefinition<>))
            .Unless(t => t.IsAbstract || t.IsInterface)
            .WithServices(typeof(IDefinition<IEntity>))
            .LifestyleTransient());
