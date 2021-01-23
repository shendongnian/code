    [XmlElement("AttributeValue", IsNullable = true)]
    public ExtendedAttributeValue[] Values { get; set; }
    
    
    public class ExtendedAttributeValue {
    		[XmlAttribute("type", DataType = "string", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    		public string Type { get; set; }
    
    		[XmlText]
    		public string Value { get; set; }
    }
