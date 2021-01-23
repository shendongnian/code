    [XmlType("MapItem", Namespace="")]
    public class MapItem
    {
        [XmlElement(Namespace="Company.Domain.Name.Space")]
        public string EpgId { get; set; }
    }
    [XmlType("Grant", Namespace="")]
    public class Grant
    {
        [XmlAttribute("ResourceId")]
        public string ResourceId { get; set; }
    }
