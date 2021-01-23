    [Serializable]
    [XmlRootAttribute(IsNullable = false, ElementName = "Bills",Namespace ="")]
    public class Bill
    {
        [XmlElement("Date")]
        public DateTime Date {get;set;}
    
        [XmlArray(ElementName = "Products")]
        public List<Product> Products { get; set; }
    }
