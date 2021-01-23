    [XmlRoot(ElementName = "Indicator")]
    [XmlType(Namespace = "http://stix.mitre.org/Indicator-2", TypeName = "IndicatorType")]
    public class IndicatorType : IndicatorBaseType
    {
        [XmlElement("Title", Namespace = "http://stix.mitre.org/Indicator-2")]
        public string Title { get; set; }
        [XmlElement("Type", Namespace = "http://stix.mitre.org/default_vocabularies-1")]
        public List<ControlledVocabularyStringType> Type { get; set; }
        [XmlElement("Description", Namespace = "http://stix.mitre.org/Indicator-2")]
        public string Description { get; set; }
        [XmlAttribute, System.ComponentModel.DefaultValueAttribute(false)]
        public bool negate { get; set; }
    }
