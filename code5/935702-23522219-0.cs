    public class SomeClass
    {
        public int SomeInt { get; set; }
        public string SomeString { get; set; }
    
        [XmlElement]
        public List<string> SomeStrings { get; set; }
    }
