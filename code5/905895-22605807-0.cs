    [Serializable()]
    public class Employee
    {
        [System.Xml.Serialization.XmlElement("RES_UID")]
        public int RES_UID { get; set; }
    
        [System.Xml.Serialization.XmlElement("RES_NAME")]
        public String RES_NAME { get; set; }
    
        [System.Xml.Serialization.XmlElement("RES_CODE")]
        public String RES_CODE { get; set; }
    
        [System.Xml.Serialization.XmlElement("RES_GROUP")]
        public String RES_GROUP { get; set; }
    
        [System.Xml.Serialization.XmlElement("RES_COST_CENTER")]
        public String RES_COST_CENTER { get; set; }
    
        public Employee()
        { }
    
        public Employee(int r_id, String res_name, String res_code, String res_group, String res_cost_center)
        {
            this.RES_UID = r_id;
            this.RES_NAME = res_name;
            this.RES_CODE = res_code;
            this.RES_GROUP = res_group;
            this.RES_COST_CENTER = res_cost_center;
        }
    }
    
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("ResourceDataSet", Namespace = "http://schemas.microsoft.com/office/project/server/webservices/ResourceDataSet/")]
    public class EmployeeList //: IEnumerator, IEnumerable
    {
        public EmployeeList() {Items = new List<Employee>();}
    
        [XmlElement("Resources", Type = typeof(Employee))]
        public List<Employee> Items {get;set;}
    }
    }
