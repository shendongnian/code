        [XmlTypeAttribute("ClientInformation")]
    public class ClientInfo
    {
        public ClientInfo()
        {
            ClientName = "testclient";
            ClientDisplayFullName = "testclient";
            ClientDisplayShortName = "testclient";
            ContentClientName = "";
            ContentHierarchy = new List<string>();
        }
        /// <summary>
        /// The "ShortName" for this client (URL Friendly)
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// This is used to determine what content path to use for content.
        /// normally the same as the ClientName.
        /// </summary>
        public string ContentClientName { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("Content", IsNullable = false)]
        public List<string> ContentHierarchy { get; set; }
        public string ClientDisplayFullName { get; set; }
        public string ClientDisplayShortName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string xml = "<ClientInformation>    <ClientName>ABC</ClientName>    <ContentClientName>ABC</ContentClientName>    <ClientDisplayFullName>ABC&amp;D</ClientDisplayFullName>    <ClientDisplayShortName>ABC&amp;D</ClientDisplayShortName>    <ContentHierarchy>        <Content>XYZB</Content>        <Content>Base</Content>    </ContentHierarchy></ClientInformation>";
            var xmlSerializer = new XmlSerializer(typeof(ClientInfo));
            var a = xmlSerializer.Deserialize(new MemoryStream(UTF8Encoding.Default.GetBytes(xml)));
        }
    
    }
