    [XmlRoot("Item")]
    public class ParentNodeName
    {
        [XmlElement("TransactionDate")]
        public string TransactionData { get; set; }
    
        [XmlElement("Product")]
        public Product MyProduct { get; set; }
    
        [XmlElement("Warning")]
        public Warning MyWarning { get; set; }
    }
    
    public class Product
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
    
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
    
    public class Warning
    {
        [XmlAttribute("message")]
        public string Message { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
    
            XmlSerializer serializer = new XmlSerializer(typeof(ParentNodeName));
    
            FileStream stream = new FileStream(@"FakeData.xml", FileMode.Open);
    
            var item = (ParentNodeName)serializer.Deserialize(stream);
        }
    }
