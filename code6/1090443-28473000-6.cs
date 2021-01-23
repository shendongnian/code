    public class Document
    {
        [XmlArray("create")]
        [XmlArrayItem("vendor", typeof(Vendor))]
        [XmlArrayItem("customer", typeof(Customer))]
        [XmlArrayItem("asset", typeof(Asset))]
        public CreateBase [] Create { get; set; }
    }
