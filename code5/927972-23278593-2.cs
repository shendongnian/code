    public class MyClass
    {
       [XmlElement("a", Type = typeof(int))]
       [XmlElement("b", Type = typeof(string))]
       [XmlElement("c", Type = typeof(float))]
        public object Value { get; set; }
    }
	
