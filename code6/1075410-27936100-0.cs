    [XmlRoot("export")]
    public class Export
    {
        [XmlElement("order")]
        public Order order {get; set;}
    }
    
    public class Order
    {
        [XmlElement("ordernumber")]
        public int orderNumber { get; set; }
        [XmlArray("items"), XmlArrayItem("item")]
        public Item[] items { get; set; }
    }
    
    public class Item
    {
        public string name { get; set; }
    }
    
    static void Serialize(string file, Export export)
    {
        var serializer = new XmlSerializer(typeof(Export));
        using (var stream = File.Create(file))
            serializer.Serialize(stream, export);
    }
    
    static Export Deserialize(string file)
    {
        var serializer = new XmlSerializer(typeof(Export));
        using (var stream = File.OpenRead(file))
            return (Export) serializer.Deserialize(stream);
    }
