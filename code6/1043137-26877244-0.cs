    [XmlRoot("someclass")]
    public class SomeClass {
        [XmlElement("some-string")]
        public SomeOtherClass Foo {get;set;}
    }
    public class SomeOtherClass {
        [XmlText]
        public string Text {get;set;}
        [XmlAttribute("alt-name")]
        public string Bar {get;set;}
    }
