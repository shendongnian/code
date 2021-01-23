    public class CustomMessageHeaderAdder : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //HttpResponseMessageProperty.Name returns "httpResponse".
            HttpResponseMessageProperty httpProp = null;
            if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                httpProp = (HttpResponseMessageProperty) reply.Properties[HttpResponseMessageProperty.Name];
            }
            else
            {
                httpProp = new HttpResponseMessageProperty();
                reply.Properties.Add(HttpResponseMessageProperty.Name, httpProp);
            }
            httpProp.Headers.Add("YouHeader", "YourValue");
        }
    }
    //following approach is to add this behavior through config file. You can implement attribute based one
    public class CustomMessageHeaderAdderBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            throw new Exception("Behavior not supported on the consumer side!");
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var messageChanger = new CustomMessageHeaderAdder();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(messageChanger);
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
    public class CustomMessageHeaderAdderExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new CustomMessageHeaderAdderBehavior();
        }
        public override Type BehaviorType
        {
            get
            {
                return typeof(CustomMessageHeaderAdderBehavior);
            }
        }
    }
