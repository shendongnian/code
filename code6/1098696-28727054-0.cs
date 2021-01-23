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
                namespaces.Add("xsi", xsi);
                namespaces.Add("xsd", xsd);
                return namespaces;
            }
        }
        public string personnel_id { get; set; }
        public string dob { get; set; }
    }
