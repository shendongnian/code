            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "DependencyInjectionExample.Test"),
                WithMappings.FromAllInterfaces, // This way you have the same instance for each interface the class implements
                UnityNamedInstance.AttributeNameOrDefault, // Use our helper to solve the name of the instance
                WithLifetime.ContainerControlled);
