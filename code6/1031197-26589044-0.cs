    [Serializable]
    public class ServerData
    {
        public bool Result { get; set; }
    
        public int Int1 { get; set; }
    
        public string Str1 { get; set; }
    
        public string Str2 { get; set; }
    
        public static string Serialize(ServerData dto)
        {
            //Add an empty namespace and empty value
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer ser = new XmlSerializer(typeof(ServerData));
            using (StringWriter textWriter = new StringWriter())
            {
                ser.Serialize(textWriter, dto, ns);
                return textWriter.ToString();
            }
        }
    
        public static ServerData Deserialize(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ServerData));
            using (var reader = new StringReader(xml))
            {
                return (ServerData)ser.Deserialize(reader);
            }
        }
    }
