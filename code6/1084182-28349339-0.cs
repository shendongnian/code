    void Main()
    {
        var endpoint = new Uri("http://somewhere/");
    
        var behaviours = new List<IEndpointBehavior>()
        {
            new SkipConfiguredPropertiesBehaviour(),
        };
    
        var channel = Create<IRemoteService>(endpoint, GetBinding(endpoint), behaviours);
        channel.SendData(new Data()
        {
            SendThis = "This should appear in the HTTP request.",
            DoNotSendThis = "This should not appear in the HTTP request.",
        });
    }
    
    [ServiceContract]
    public interface IRemoteService
    {
        [OperationContract]
        int SendData(Data d);
    }
    
    public class Data
    {
        public string SendThis { get; set; }
        public string DoNotSendThis { get; set; }
    }
    
    public class SkipConfiguredPropertiesBehaviour : IEndpointBehavior
    {
       public void AddBindingParameters(
            ServiceEndpoint endpoint,
            BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyClientBehavior(
            ServiceEndpoint endpoint, 
            ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new SkipConfiguredPropertiesInspector());
        }
    
        public void ApplyDispatchBehavior(
            ServiceEndpoint endpoint, 
            EndpointDispatcher endpointDispatcher)
        {
        }
    
        public void Validate(
            ServiceEndpoint endpoint)
        {
        }
    }
    
    public class SkipConfiguredPropertiesInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(
            ref Message reply, 
            object correlationState)
        {
            Console.WriteLine("Received the following reply: '{0}'", reply.ToString());
        }
    
        public object BeforeSendRequest(
            ref Message request, 
            IClientChannel channel)
        {     
            Console.WriteLine("Was going to send the following request: '{0}'", request.ToString());
    
            //TODO: Update the message here.
    
            return null;
        }
    }
    
     public static T Create<T>(Uri endpoint, Binding binding, List<IEndpointBehavior> behaviors = null)
    {
        var factory = new ChannelFactory<T>(binding);
    
        if (behaviors != null)
        {
            behaviors.ForEach(factory.Endpoint.Behaviors.Add);
        }
    
        return factory.CreateChannel(new EndpointAddress(endpoint));
    }
    
    public static BasicHttpBinding GetBinding(Uri uri)
    {
        var binding = new BasicHttpBinding()
        {
            MaxBufferPoolSize = 524288000, // 10MB
            MaxReceivedMessageSize = 524288000,
            MaxBufferSize = 524288000,
            MessageEncoding = WSMessageEncoding.Text,
            TransferMode = TransferMode.Buffered,
            Security = new BasicHttpSecurity()
            {
                Mode = uri.Scheme == "http" ? BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport,
            }
        };
    
        return binding;
    }
