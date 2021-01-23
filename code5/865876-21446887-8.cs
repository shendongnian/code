    using System.XML.Serialization
    public class reportParameterTestSettings
    {
        [XmlElement("Report")]
        public List<ReportParameters> Report { get; set; }
       
        [XmlAttribute("Uri")]
        public string Uri { get; set; }
    }
    public class ReportParameters
    {
        public string WorkItemType { get; set; }
        public string CurrentUser { get; set; }
        ...etc ...etc
    }
