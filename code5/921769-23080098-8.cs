    [DataContract(Namespace = "http://my.full.namespece.com")]
    public class BaseClass
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://my.full.namespece.com")]
    public class ChildClass : BaseClass
    {
        [XmlElement(ElementName = "SecondName")]
        public string SecondName { get; set; }
        [XmlElement(ElementName = "Age")]
        public int Age { get; set; }
    }
