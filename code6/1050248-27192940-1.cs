    public class MyBodyWriter : BodyWriter
    {
        public CompositeType CompositeType { get; private set; }
        public MyBodyWriter(CompositeType composite)
            : base(false)
        {
            CompositeType = composite;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
           writer.WriteStartElement("GetDataUsingDataContractResponse", "http://tempuri.org/");
           writer.WriteStartElement("GetDataUsingDataContractResult");
           writer.WriteAttributeString("xmlns", "a", null, "http://schemas.datacontract.org/2004/07/WcfService1");
           writer.WriteAttributeString("xmlns", "i", null, "http://www.w3.org/2001/XMLSchema-instance");
           writer.WriteStartElement("a:BoolValue");
           writer.WriteString(CompositeType.BoolValue.ToString().ToLower());
           writer.WriteEndElement();
           writer.WriteStartElement("a:StringValue");
           writer.WriteString(CompositeType.StringValue);
           writer.WriteEndElement();
           writer.WriteEndElement();
        }
    }
