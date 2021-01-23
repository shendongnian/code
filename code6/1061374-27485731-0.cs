    [System.Xml.Serialization.XmlRootAttribute(ElementName = "DeviceRequest")]
    public class Display : DeviceRequest
    {
        public static Display ParseRequest(string sXML)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Display));
            StringReader sr = new StringReader(sXML);
            NamespaceIgnorantXmlTextReader XMLWithoutNamespace = new NamespaceIgnorantXmlTextReader(sr);
            return (Display)serializer.Deserialize(XMLWithoutNamespace);
        }
        [XmlAttribute()]
        public override string RequestType
        {
            get { return "O"; } set { } 
        }
        public override byte[] Message()
        {
            throw new NotImplementedException();
        }
    }
