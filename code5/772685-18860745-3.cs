    public class MainObject : IXmlSerializable
    {
        public HelperContainer { get; set; }
    
        public string Others { get; set; }
    
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteString(Others);
            writer.WriteAttributeString("foo", HelperContainer.Foo);
            writer.WriteAttributeString("bar", HelperContainer.Bar);
        }
    
        public void ReadXml (XmlReader reader)
        {
            Others = reader.ReadString();
            //...
        }
    }
