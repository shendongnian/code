    public class GenericImplementationMatchingStrategy : IGenericImplementationMatchingStrategy
    {
        public static ConcurrentDictionary<string, Type[]> dicStrategyCommandHandler = new ConcurrentDictionary<string, Type[]>();
        public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
        {
            return dicStrategyCommandHandler.GetOrAdd(context.RequestedType.FullName, (key) =>
                {
                    
                    if (context.RequestedType.GetGenericTypeDefinition() == typeof(ICommandHandler<,>))
                    {
                        var service = model.Implementation.GetInterfaces().Where(p => { return p.Name == context.RequestedType.Name; }).FirstOrDefault(); //  model.Implementation.GetInterfaces()[0];
                        if (service != null)
                        {
                            List<Type> types = new List<Type>();
                            foreach (var item in model.Implementation.GetGenericArguments())
                            {
                                var name = item.Name;
                                var type = serviceGetType(name, service, context.RequestedType);
                                types.Add(type);
    
                            }
                            return types.ToArray();
                        }
                    }
                    return null;
                }
                );
        }
    
        private Type serviceGetType(string name, Type service, Type requestedType)
        {
            var args = service.GetGenericArguments().ToArray();
            var argsRequested = requestedType.GetGenericArguments().ToArray();
            for (int i=0;i<args.Count();i++ )
            {
                Type itemDecla = args[i];
                Type itemRequested = argsRequested[i];
                if (itemDecla.Name == name)
                    return itemRequested;
                else
                {
                    var recur = serviceGetType(name, itemDecla, itemRequested);
                    if (recur != null) return recur;
                }
            }
            return null;
        }
    }
