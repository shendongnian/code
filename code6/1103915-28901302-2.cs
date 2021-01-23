            public class BaseServiceConvention : IRegistrationConvention
            {
                public void Process(Type type, Registry registry)
                {
                    if (!type.IsConcrete())
                    {
                        return;
                    }
    
                    var interfaceTypes = type.FindInterfacesThatClose(typeof(BaseService<>));
    
                    foreach (var closedGenericType in interfaceTypes)
                    {
                        if (GenericsPluginGraph.CanBeCast(closedGenericType, type))
                        {
                            registry.For(closedGenericType).Singleton().Use(type).Named(type.Name);
                        }
                    }
                }
            }
