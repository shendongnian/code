    public class ClientMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //following example is for adding http header.   
            //If you have another protocol you can add any other message  
            //manipulation code instead.
            //HttpResponseMessageProperty.Name returns "httpResponse".
            HttpResponseMessageProperty httpProp = null;
            if (request.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                httpProp = (HttpResponseMessageProperty)request.Properties[HttpResponseMessageProperty.Name];
            }
            else
            {
                httpProp = new HttpResponseMessageProperty();
                request.Properties.Add(HttpResponseMessageProperty.Name, httpProp);
            }
            httpProp.Headers.Add("YouHeader", "YourValue");
            return null;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState) { }
    }
    public class ClientMessageInspectorBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ClientMessageInspector());
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
    public class ClientMessageInspectorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new ClientMessageInspectorBehavior();
        }
        public override Type BehaviorType
        {
            get
            {
                return typeof(ClientMessageInspectorBehavior);
            }
        }
    }
