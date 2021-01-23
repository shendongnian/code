    [XmlElement(ElementName = "Listing")]
    public ClassificationWrapper classificationWrapper { get; set; }
    
    public class ClassificationWrapper
    {
    	[XmlAttribute("reference")]
            public string ref= "MyReference";
    
            [XmlElement("Classification", typeof(Classification))]
            public List<Classification> classifications { get; set; }
    
    public ClassificationWrapper() { this.classifications = new List<Classification>(); }
    }
    public class Classification
    {
           [XmlAttribute("Name")]
           public string name { get; set; }
    
           [XmlText]
           public string Value { get; set; }
    }
