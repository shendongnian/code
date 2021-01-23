    [DataContract(Namespace = "", Name = "application")]
    [XmlType(TypeName = "application")]
    public class ApplicationDTO
    {
        [DataMember(Name = "application-name")]
        [XmlElement(ElementName = "application-name")]
        public string ApplicationName { get; set; }
    }
