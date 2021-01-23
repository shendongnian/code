    [XmlRoot("Items")]
    public class Foo {
        public string Product {get;set;}
        private readonly List<string> items = new List<string>();
        [XmlElement("Item")]
        public List<string> Items {get{return items;}}
    }
