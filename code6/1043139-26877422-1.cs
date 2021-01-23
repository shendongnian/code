    [Serializable()]
    [XmlRoot(Namespace = "someclass", IsNullable = false)]  
    public class someclass
    {
        [XmlElement("some-string")] 
        public StringWrapper somestring { get; set; }
    }
