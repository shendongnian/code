    public class Item
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("Entry")]
        public string Entry { get; set; }
    }
