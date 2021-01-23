            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "DependencyInjectionExample.Test"),
                WithMappings.FromAllInterfaces,
                UnityNamedInstance.AttributeNameOrDefault,
                WithLifetime.ContainerControlled);
