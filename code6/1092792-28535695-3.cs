    public class Group : SomeType
    {
        
        [XmlArrayItem(typeof(SomeType),ElementName = "anyType", Namespace = "http://custom/a")]
        public List<SomeType> Elements { get; set; }
    }
    public class SomeType
    {
        [XmlElement(typeof(string),ElementName="DisplayName",Namespace="")]
        public string DisplayName { get; set; }
    }
