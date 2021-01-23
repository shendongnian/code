    unityContainer.RegisterTypes(
        AllClasses.FromAssembliesInBasePath()
            .Where(t => t.GetInterfaces().Any(
                i => i.IsGenericType
                && i.GetGenericTypeDefinition() == typeof(IMessageListener<>))),
        WithMappings.FromAllInterfacesInSameAssembly,
        WithName.Default,
        WithLifetime.ContainerControlled,
        null,
        true);
