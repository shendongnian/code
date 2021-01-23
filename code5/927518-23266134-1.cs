    container.Register(
        // we want all concrete classes in this assembly
        Classes.FromThisAssembly()
        // but we filter them to keep only the ones in a specific namespace
        .InSameNamespaceAs<RootComponent>()
        // we register thoses classes to interfaces that match the classes names
        .WithService.DefaultInterfaces()
        // setting the lifestyles for all components in this batch
        .LifestyleTransient()
    );
