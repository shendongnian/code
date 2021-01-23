    public class UnityInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly IUnityContainer container;
        public UnityInstanceProvider(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return container.Resolve(instanceContext.Host.Description.ServiceType);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
