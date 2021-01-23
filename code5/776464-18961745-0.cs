    public class Resource
    {
        [XmlArrayItem("Create", typeof(Create))]
        [XmlArrayItem("Delete", typeof(Delete))]    
        public List<Operation> {get; set;}
    }
