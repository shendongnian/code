    [Serializable]
    [XmlType("Job")]
    public class Job
    {
        [XmlAttribute("Job_Code")]
        public string JobCode { get; set; }
    
        [XmlAttribute("Status")]
        public string Status { get; set; }
    }
