    public class ServiceHandlersFilter : IHandlersFilter
    {
        private readonly List<Type> sortOrder = new List<Type>
                                                    {
                                                       { typeof(Service1) },
                                                       { typeof(Service2) },
                                                       { typeof(Service3) },
                                                    };
    
        public bool HasOpinionAbout(Type service)
        {
            return service == typeof(IService);
        }
    
        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            return handlers
                .OrderBy(h => sortOrder.IndexOf(h.ComponentModel.Implementation))
                .ToArray();
        }
    }
