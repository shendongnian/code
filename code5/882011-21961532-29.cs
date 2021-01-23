            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "DependencyInjectionExample.Test"),
                WithMappings.FromAllInterfaces,
                WithName.TypeName, // Use the type name for the instances
                WithLifetime.ContainerControlled);
