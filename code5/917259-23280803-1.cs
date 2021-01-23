    [DataContract, XmlRoot("Person")]
    public class Person: BaseEntity
    {
        [DataMember, XmlElement]
        public DomainString Prefix { get; set; }
        [DataMember, XmlElement]
        public DomainString FirstName { get; set; }
        [DataMember, XmlElement]
        public DomainString MiddleName { get; set; }
        [DataMember, XmlElement]
        public DomainString LastName { get; set; }
        [DataMember, XmlElement]
        public DomainString MaidenName { get; set; }
    }
    
    public class DomainString{
        public string Value {get; set;}
        public bool IsNull {get; set;}
    }
