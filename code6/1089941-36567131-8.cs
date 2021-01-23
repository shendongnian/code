    public class RateLimiterDispatchMessageInspector : IDispatchMessageInspector
    {
        private readonly IRateLimiter _rateLimiter;
        public RateLimiterDispatchMessageInspector(IRateLimiter rateLimiter)
        {
            _rateLimiter = rateLimiter;
        }
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (_rateLimiter.ShouldLimit(request.GetClientIp()))
            {
                request = null;
                return _rateLimiter.LimitStatusCode;
            }
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (correlationState is HttpStatusCode)
            {
                HttpResponseMessageProperty responseProperty = new HttpResponseMessageProperty();
                reply.Properties["httpResponse"] = responseProperty;
                responseProperty.StatusCode = (HttpStatusCode)correlationState;
            }
        }
    }
    public class RateLimiterServiceBehavior : IServiceBehavior
    {
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var rateLimiterFactory = new RateLimiterFactory();
            foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                {
                    epDisp.DispatchRuntime.MessageInspectors.Add(new RateLimiterDispatchMessageInspector(rateLimiterFactory.CreateRateLimiter()));
                }
            }
        }
    }
    public class RateLimiterBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new RateLimiterServiceBehavior();
        }
        public override Type BehaviorType
        {
            get { return typeof(RateLimiterServiceBehavior); }
        }
    }
