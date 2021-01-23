    [XmlType("MESSAGE")]
    public class Message
    {
        [XmlElement("FROM")]
        public string From { get; set; }
        [XmlArray("EMAILRECIPIENTS")]
        [XmlArrayItem("TO")]
        public List<string> Recipients { get; set; }
        [XmlElement("SUBJECT")]
        public string Subject { get; set; }
        [XmlElement("BODY")]
        public string Body { get; set; }
        [XmlArray("ATTACHED")]
        [XmlArrayItem("CONTENT")]
        public List<string> Attachments { get; set; }
    }
