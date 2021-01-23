    public class TestXML : IXmlSerializable
    {
        public String Label = "Hello";
        public Boolean Enable = true;
        public Int32 PosX = 12;
        public Int32 PosY = 34;
        public void WriteXml(XmlWriter writer)
        {
            // Serialize
        }
        public void ReadXml(XmlReader reader)
        {
            // Deserialize
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
