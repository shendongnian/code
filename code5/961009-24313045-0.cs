    XmlSerializer deserializer = new XmlSerializer(typeof(AllReports));
    TextReader tr = new StreamReader(filename);
    AllReports reports = (AllReports)deserializer.Deserialize(tr);
---
    [XmlType("sms_message")]
    public class SMSMessage
    {
        [XmlElement("number")]
        public string Number { get; set; }
        [XmlElement("text")]
        public string TheText { get; set; }
    }
    [XmlType("report")]
    public class AReport
    {
        [XmlArray("sms_messages")]
        public List<SMSMessage> SMSMessages = new List<SMSMessage>();
    }
    [XmlRoot("reports")]
    public class AllReports
    {
        [XmlElement("report")]
        public List<AReport> Reports = new List<AReport>();
    }
