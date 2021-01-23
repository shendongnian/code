    public class ServerInterceptor: IDispatchMessageInspector, IEndpointBehavior
    {
        object IDispatchMessageInspector.AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }
        void IDispatchMessageInspector.BeforeSendReply(ref Message reply, object correlationState)
        {
            reply.Headers.Add(MessageHeader.CreateHeader("header", "namespace", "headervalue"));
        }
        void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }
        void IEndpointBehavior.Validate(ServiceEndpoint endpoint){}
        void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters){}
        void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime){}
    }
	
