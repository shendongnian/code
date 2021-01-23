    internal class BasicAuthenticationBehavior : IEndpointBehavior
    {
        private readonly string _username;
        private readonly string _password;
    
        public BasicAuthenticationBehavior(string username, string password)
        {
            this._username = username;
            this._password = password;
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            var inspector = new BasicAuthenticationInspector(this._username, this._password);
            clientRuntime.MessageInspectors.Add(inspector);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }
        public void Validate(ServiceEndpoint endpoint) { }
    }
    
    internal class BasicAuthenticationInspector : IClientMessageInspector
    {
        private readonly string _username;
        private readonly string _password;
    
        public BasicAuthenticationInspector(string username, string password)
        {
            this._username = username;
            this._password = password;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState) { }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            // we add the headers manually rather than using credentials 
            // due to proxying issues, and with the 101-continue http verb 
            var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(this._username + ":" + this._password));
            var messageProperty = new HttpRequestMessageProperty();
            messageProperty.Headers.Add("Authorization", "Basic " + authInfo);
            request.Properties[HttpRequestMessageProperty.Name] = messageProperty;
            return null;
        }
    }
