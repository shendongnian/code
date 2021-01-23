    public class CookieBehavior : IEndpointBehavior
    {
        private CookieContainer cookieCont;
        public CookieBehavior(CookieContainer cookieCont)
        {
            this.cookieCont = cookieCont;
        }
 
        public void AddBindingParameters(ServiceEndpoint serviceEndpoint,
            System.ServiceModel.Channels
            .BindingParameterCollection bindingParameters) { }
 
        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint,
            System.ServiceModel.Dispatcher.ClientRuntime behavior)
        {
            behavior.MessageInspectors.Add(new CookieMessageInspector(cookieCont));
        }
 
        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint,
            System.ServiceModel.Dispatcher
            .EndpointDispatcher endpointDispatcher) { }
 
        public void Validate(ServiceEndpoint serviceEndpoint) { }
    }
