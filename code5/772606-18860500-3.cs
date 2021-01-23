       [XmlRoot(ElementName = "contact")]
       public class ContactField
            {
                [XmlElement("id")]
                public int id { get; set; }
    
                [XmlElement("type")]
                public string type { get; set; }
    
                [XmlElement("fields")]
                public Field[] fields { get; set; }
            }
    
            public class Field
            {
                [XmlElement("value")]
                public SubField SubField { get; set; }
            }
    
            public class SubField
            {
                [XmlText]
                public String Value { get; set; }
    
                [XmlElement("day")]
                public String Day { get; set; }
    
                [XmlElement("month")]
                public String Month { get; set; }
    
                [XmlElement("year")]
                public String Year { get; set; }
            }
