    public class CustomBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {}
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            var inspector = new CustomMessageInspector();
            clientRuntime.MessageInspectors.Add(inspector);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {}
        public void Validate(ServiceEndpoint endpoint)
        {}
    }
    public class CustomMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {}
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.Add(new MyMessageHeader());
            return null;
        }
    }
    public class MyMessageHeader : MessageHeader
    {
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteRaw(String.Format(@"
            <UsernameToken xmlns=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
            <Username>user</Username>
            <Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest"">pass</Password>
            </UsernameToken>").Trim());
        }
        public override string Name
        {
            get { return "MyHeaderName"; }
        }
        public override string Namespace
        {
            get { return "MyHeaderNamespace"; }
        }
    }
