    [XmlRoot("Param")]
    public class MyClass
    {
        [XmlArray("MyList")]
        [XmlArrayItem("mynode")]
        public List<string> MyList { get; set; }
    }
