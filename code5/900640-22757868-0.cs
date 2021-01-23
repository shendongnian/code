    public class Service : DataService<Context>, IServiceProvider 
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceActionAccessRule("*", ServiceActionRights.Invoke);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
        public object GetService(Type serviceType)
        {
            return typeof(IDataServiceActionProvider) == serviceType ? new ActionProvider() : null;
        }
    }
    public class ActionProvider : IDataServiceActionProvider, IDataServiceActionResolver
    {
        private static List<ServiceAction> actions;
        static ActionProvider()
        {
            ServiceAction movieRateAction = new ServiceAction(
                 "Action1", // name of the action 
                 ResourceType.GetPrimitiveResourceType(typeof(string)), // no return type i.e. void 
                 null, // no return type means we don’t need to know the ResourceSet so use null. 
                 OperationParameterBindingKind.Never,
                 new ServiceActionParameter[] { 
                  new ServiceActionParameter("val", ResourceType.GetPrimitiveResourceType(typeof(string))) 
               }
                );
            movieRateAction.SetReadOnly();
            actions = new List<ServiceAction>() { movieRateAction };
        }
        public IEnumerable<ServiceAction> GetServiceActions(DataServiceOperationContext operationContext)
        {
            return actions;
        }
        public bool TryResolveServiceAction(DataServiceOperationContext operationContext, string serviceActionName,
                                            out ServiceAction serviceAction)
        {
            serviceAction = null;
            return false;
        }
        public IEnumerable<ServiceAction> GetServiceActionsByBindingParameterType(DataServiceOperationContext operationContext,
                                                                   ResourceType bindingParameterType)
        {
            return Enumerable.Empty<ServiceAction>();
        }
        public IDataServiceInvokable CreateInvokable(DataServiceOperationContext operationContext, ServiceAction serviceAction,
                                                     object[] parameterTokens)
        {
            return new DataServiceInvokable(parameterTokens);
        }
        public bool AdvertiseServiceAction(DataServiceOperationContext operationContext, ServiceAction serviceAction, object resourceInstance, bool resourceInstanceInFeed, ref ODataAction actionToSerialize)
        {
            actionToSerialize = null;
            return false;
        }
        public bool TryResolveServiceAction(DataServiceOperationContext operationContext, ServiceActionResolverArgs resolverArgs, out ServiceAction serviceAction)
        {
            serviceAction = actions[0];
            return true;
        }
    }
     public class DataServiceInvokable : IDataServiceInvokable
     {
         private readonly object[] parameters;
         private string result;
         public DataServiceInvokable(object[] parameters)
         {
             this.parameters = parameters;
         }
         public object GetResult()
         {
             return result;
         }
         public void Invoke()
         {
             result = parameters[0] as string;
         }
     }
