    using System.XML.Serialization
    public class reportParameterTestSettings
    {
        public List<ReportParameters> Report { get; set; }
    }
    public class ReportParameters
    {
        public string WorkItemType { get; set; }
        public string CurrentUser { get; set; }
        ...etc ...etc
    }
