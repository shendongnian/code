    public class Test:IXmlSerializable
    {
        public string Prop;
        
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteAttributeString("Prop", Prop ?? "");
        }
    
        public void ReadXml (XmlReader reader)
        {
            if(reader.HasAttributes)
            {
                Prop = reader.GetAttribute("Prop");
            }
        }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
