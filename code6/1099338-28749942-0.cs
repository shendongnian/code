    [XmlRoot("MT_Get_Name_Res", Namespace = "http://hse.pd.com")]
    public class EmployeeSAPObject
    {
        [XmlElement(Namespace="")]
        public string fullname { get; set; }
        [XmlElement(Namespace = "")]
        public string error { get; set; }
    }
