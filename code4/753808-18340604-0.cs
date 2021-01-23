    class Program
    {
        static void Main(string[] args)
        {
            string testData = @"<?xml version=""1.0""?>
    <PropertiesMapping>
        <Property>
            <WEB_Class>InfoRequest</WEB_Class>
            <COM_Class>CInfoReq</COM_Class>
            <Mappings>
                <Map>
                    <WEB_Property>theId</WEB_Property>
                    <COM_Property>TheID</COM_Property>
                </Map>
                <Map>
                    <WEB_Property>theName</WEB_Property>
                    <COM_Property>NewName</COM_Property>
                </Map>
            </Mappings>
        </Property>
    </PropertiesMapping>";
            var sr = new System.IO.StringReader(testData);
            var xs = new XmlSerializer(typeof(PropertiesMapping));
            object result = xs.Deserialize(sr);
        }
    }
    [Serializable]
    public class PropertiesMapping
    {
        public Property Property { get; set; }
    }
    [Serializable]
    public class Property
    {
        [XmlElement("WEB_Class")]
        public string WebClass { get; set; }
        [XmlElement("COM_Class")]
        public string ComClass { get; set; }
        [XmlArrayItem("Map")]
        public Mapping[] Mappings { get; set; }
    }
    [Serializable]
    public class Mapping
    {
        [XmlElement("WEB_Property")]
        public string WebProperty { get; set; }
        [XmlElement("COM_Property")]
        public string ComProperty { get; set; }
    }
