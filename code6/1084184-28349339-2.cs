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
    
            request = TransformMessage(request);
    
            return null;
        }
        
        private Message TransformMessage(Message oldMessage)
        {
            Message newMessage = null;
            MessageBuffer msgbuf = oldMessage.CreateBufferedCopy(int.MaxValue);
            XPathNavigator nav = msgbuf.CreateNavigator();
        
            //load the old message into xmldocument
            var ms = new MemoryStream();
            using(var xw = XmlWriter.Create(ms))
            {
                nav.WriteSubtree(xw);
                xw.Flush();
                xw.Close();
            }
        
            ms.Position = 0;
            XDocument xdoc = XDocument.Load(XmlReader.Create(ms));
        
            //perform transformation
            var elementsToRemove = xdoc.Descendants().Where(d => d.Name.LocalName.Equals("DoNotSendThis")).ToArray();
            
            foreach(var e in elementsToRemove)
            {
                e.Remove();
            }
        
            // have a cheeky read...
            StreamReader sr = new StreamReader(ms);
            Console.WriteLine("We're really going to write out: " + xdoc.ToString());
        
            //create the new message           
            newMessage = Message.CreateMessage(xdoc.CreateReader(), int.MaxValue, oldMessage.Version);
        
            return newMessage;
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
