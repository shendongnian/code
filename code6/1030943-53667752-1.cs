    public class StructureMapServiceBehavior : IServiceBehavior
    {
        private readonly IContainer _container;
        public StructureMapServiceBehavior(IContainer container)
        {
            _container = container;
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                foreach (var ed in channelDispatcher.Endpoints)
                    ed.DispatchRuntime.InstanceProvider = new StructureMapInstanceProvider(_container, serviceDescription.ServiceType);
            }
        }
    }
