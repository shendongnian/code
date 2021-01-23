    [XmlRoot("MyTs")]
    public class MyRoot
    {
        [XmlAttribute]
        public string Name { get; set; }
    
        //[XmlElement]
        public string Description { get; set; }
        private readonly HashSet<MyT> items = new HashSet<MyT>();
        [XmlElement("MyT")] 
        public HashSet<MyT> Items {get { return items;}}
    }
