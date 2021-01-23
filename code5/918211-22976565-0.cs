    public class MyStuff : IXmlSerializable {
        public string Name { get; set; }
        public List<Annotation> Annotations { get; set; }
        public XmlSchema GetSchema() {
            return null;
        }
        public void ReadXml(XmlReader reader) {
            // customized deserialization
            // reader.GetAttribute() or whatever
        }
        public void WriteXml(XmlWriter writer) {
            // customized serialization
            // writer.WriteAttributeString() or whatever
        }
    }
