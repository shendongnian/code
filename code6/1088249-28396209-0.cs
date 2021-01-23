    var list = new List<Item>()
    {
    	new Item(),
    	new Item()
    };
    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Item>));
    
    using (var stream = File.Open("Document.xml", FileMode.CreateNew))
    {
    	xmlSerializer.Serialize(stream, list);
    }
    
    using (var stream = File.Open("Document.xml", FileMode.Open))
    {
    	xmlSerializer.Deserialize(stream);
    }
