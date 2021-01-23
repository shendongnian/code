    [XmlRoot("myclass")]
    public class MyClass
    {
        [XmlElement("subject")]
        public ValueAttribute<string> Subject { get; set; }
    
        [XmlElement("object")]
        public ValueAttribute<string> Object { get; set; }
    }
    public class ValueAttribute<T>
    {
        [XmlAttribute("value")]
        public T Value { get; set; }
        
        public static implicit operator ValueAttribute<T>(T value)
        {
            return new ValueAttribute<T> { Value = value };
        }
    }
