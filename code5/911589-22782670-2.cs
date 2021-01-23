    [XmlRoot("catalog")]
    public class Catalog
    {
    	 [XmlElement("item")] // no XmlArray/XmlArrayItem, just XmlElement
         public Item[] Items { get; set; }
    }
    
    [XmlType("item")]
    public class Item
    {
        [XmlElement("id")]
        public string id { get; set; }
    
        [XmlElement("note", typeof(Note))] // no XmlArray/XmlArrayItem, just XmlElement
        public Note[] note { get; set; }
    
        [XmlElement("relation", typeof(Relation))] // no XmlArray/XmlArrayItem, just XmlElement
        public Relation[] relation { get; set; }
    }
    
    [Serializable]
    public class Note
    {
        [XmlAttribute("label")]
        public string label { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
    
    [Serializable]
    public class Relation
    {
        [XmlAttribute("weight")]
        public string weight { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    
        [XmlElement("id")]
        public string id { get; set; }
    
        [XmlElement("type")]
        public string type { get; set; }
    
        [XmlElement("name")]
        public string name { get; set; }
    }
