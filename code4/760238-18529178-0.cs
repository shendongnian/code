    [XmlRoot("test")]
    public class Test {
        [XmlElement("items")]
        public MyListWrapper Items {get;set;}
    }
    
    public class MyListWrapper {
        [XmlAttribute("Search")]
        public string Attribute1 {get;set;}
        [XmlElement("item")]
        public List<MyItem> Items {get;set;}
    }
    public class MyItem {
        [XmlAttribute("id")]
        public int Id {get;set;}
    }
