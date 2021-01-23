    [XmlRoot("MT_Get_Name_Req", Namespace = "http://hsd.sd.com")]
    public class Employee
    {
        [XmlElement(Namespace="")]
        public string personnel_id { get; set; }
        [XmlElement(Namespace = "")]
        public string dob { get; set; }
    }
