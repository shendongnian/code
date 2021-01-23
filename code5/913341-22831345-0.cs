      container.RegisterTypes(
            AllClasses.FromAssemblies(Assembly.GetExecutingAssembly()),
            WithMappings.FromAllInterfaces,
            WithName.Default,
            WithLifetime.ContainerControlled);
