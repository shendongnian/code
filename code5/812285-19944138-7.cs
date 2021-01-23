        public class MerchantSerializer : XmlObjectSerializer
    	{
    		XmlSerializer serializer;
    
    		public MerchantSerializer()
    		{
    			this.serializer = new XmlSerializer(typeof(Merchant));
    		}
    				
    		public override void WriteObject(XmlDictionaryWriter writer, object graph)
    		{
    			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    			ns.Add("", "");
    			serializer.Serialize(writer, graph, ns);
    		}
    
    		public override bool IsStartObject(XmlDictionaryReader reader)
    		{
    			throw new NotImplementedException();
    		}
    
    		public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
    		{
    			throw new NotImplementedException();
    		}
    
    		public override void WriteEndObject(XmlDictionaryWriter writer)
    		{
    			throw new NotImplementedException();
    		}
    
    		public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
    		{
    			throw new NotImplementedException();
    		}
    
    		public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
    		{
    			throw new NotImplementedException();
    		}
    	}
