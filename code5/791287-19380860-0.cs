    public class BoolHolder : IXmlSerializable
    {
        public bool Value { get; set }
    
        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }
    
        public void ReadXml(System.Xml.XmlReader reader) {
            string str = reader.ReadString();
            reader.ReadEndElement();
    
            switch (str) {
                case "t":
                    this.Value = true;
    	...
        }
    }
