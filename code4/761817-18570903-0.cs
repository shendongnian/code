    public class XMLFile
    {
        [XmlArray("MasterFiles")]
    	[XmlArrayItem("Supplier", typeof(Supplier))]
    	[XmlArrayItem("Customer", typeof(Customer))]
        public List<MasterElement> MasterFiles;
    }
