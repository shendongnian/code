    public class StackOverflow_23979866
    {
        public class DNC
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
            public string Field3 { get; set; }
        }
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetDNCList")]
            List<DNC> GetDNCList();
        }
        public class Service : ITest
        {
            public List<DNC> GetDNCList()
            {
                return new List<DNC>
                {
                    new DNC { Field1 = "Value 1-1", Field2 = "Value 2-1", Field3 = "Value 3-1" },
                    new DNC { Field1 = "Value 1-2", Field2 = "Value 2-2", Field3 = "Value 3-2" },
                    new DNC { Field1 = "Value 1-3", Field2 = "Value 2-3", Field3 = "Value 3-3" },
                };
            }
        }
        public class MyWebHttpBehavior : WebHttpBehavior
        {
            protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
            {
                if (operationDescription.Name == "GetDNCList")
                {
                    return new MyListOfDNCReplyFormatter();
                }
                else
                {
                    return base.GetReplyDispatchFormatter(operationDescription, endpoint);
                }
            }
        }
        public class MyListOfDNCReplyFormatter : IDispatchMessageFormatter
        {
            public void DeserializeRequest(Message message, object[] parameters)
            {
                throw new NotSupportedException("This is a reply-only formatter");
            }
            public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
            {
                List<DNC> list = (List<DNC>)result;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\"Field1\",\"Field2\",\"Field3\"");
                foreach (var dnc in list)
                {
                    // may need to escape, leaving out for brevity
                    sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\"", dnc.Field1, dnc.Field2, dnc.Field3));
                }
                Message reply = Message.CreateMessage(messageVersion, null, new RawBodyWriter(sb.ToString()));
                reply.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
                HttpResponseMessageProperty httpResp = new HttpResponseMessageProperty();
                reply.Properties.Add(HttpResponseMessageProperty.Name, httpResp);
                httpResp.Headers[HttpResponseHeader.ContentType] = "text/csv";
                return reply;
            }
            class RawBodyWriter : BodyWriter
            {
                string contents;
                public RawBodyWriter(string contents)
                    : base(true)
                {
                    this.contents = contents;
                }
                protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
                {
                    writer.WriteStartElement("Binary");
                    byte[] bytes = Encoding.UTF8.GetBytes(this.contents);
                    writer.WriteBase64(bytes, 0, bytes.Length);
                    writer.WriteEndElement();
                }
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new MyWebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/GetDNCList"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
