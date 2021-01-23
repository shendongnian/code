    unityContainer.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    unityContainer.RegisterTypes(AllClasses.FromAssembliesInBasePath().Where(t => t.Namespace.StartsWith("Mynamespace.")),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.ContainerControlled,null,true);
