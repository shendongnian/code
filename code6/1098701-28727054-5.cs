    [XmlRoot("MT_Get_Name_Req", Namespace = Employee.XmlNamespace)]
    public class Employee
    {
        public const string XmlNamespace = "http://hsd.sd.com";
        public const string XmlNamespacePrefix = "ns0";
        const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
        const string xsd = "http://www.w3.org/2001/XMLSchema";
        public static XmlSerializerNamespaces XmlSerializerNamespaces
        {
            get
            {
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(XmlNamespacePrefix, XmlNamespace);
                // namespaces.Add("xsi", xsi);  Uncomment to add standard namespaces.
                // namespaces.Add("xsd", xsd);
                return namespaces;
            }
        }
        [XmlElement("personnel_id", Namespace="")]
        public string personnel_id { get; set; }
        [XmlElement("dob", Namespace = "")]
        public string dob { get; set; }
    }
