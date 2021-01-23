    [XmlRoot("root")]
    public class FooWrapper {
        [XmlElement("foo")]
        public List<Foo> Items {get;set;}
    }
