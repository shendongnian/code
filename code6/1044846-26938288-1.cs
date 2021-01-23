    public static void AutoMap(this Container container, params Assembly[] assemblies) {
        container.ResolveUnregisteredType += (s, e) => {
            if (e.UnregisteredServiceType.IsInterface && !e.Handled) {
                Type[] concreteTypes = (
                    from assembly in assemblies
                    from type in assembly.GetTypes()
                    where !type.IsAbstract && !type.IsGenericType
                    where e.UnregisteredServiceType.IsAssignableFrom(type)
                    select type)
                    .ToArray();
                if (concreteTypes.Length == 1) {
                    e.Register(Lifestyle.Transient.CreateRegistration(concreteTypes[0], 
                        container));
                }
            }
        };
    }
