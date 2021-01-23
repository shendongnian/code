    public class MaxFaultSizeBehavior : IEndpointBehavior
    {
        private readonly int _size;
        public MaxFaultSizeBehavior(int size)
        {
            _size = size;
        }
        public void Validate(ServiceEndpoint endpoint)
        {            
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {         
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {            
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MaxFaultSize = _size;
        }
    }
