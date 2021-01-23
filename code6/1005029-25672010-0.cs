    public class RawWcfMessage : IRequiresSoapMessage {
        public Message Message { get; set; }
    }
     
    public class MyServices : Service
    {
        public object Post(RawWcfMessage request) { 
            var requestMsg = request.Message... //Raw WCF SOAP Message
        }
    }
