    [XmlTypeAttribute(AnonymousType = true)]
            public class CustomData
            {
                [XmlArray(ElementName = "Records")]
                [XmlArrayItem(ElementName = "record")]
                public List<Record> Records { get; set; }
    
                public CustomData()
                {
                    Records = new List<Record>();
                }
    
            }
            public class Record
            {
                [XmlElement(ElementName = "IsEnrolled")]
                public string IsEnrolled { get; set; }
    
                [XmlElement(ElementName = "IsGraduating")]
                public string IsGraduating { get; set; }
    
                [XmlElement(ElementName = "StudentLevel")]
                public string StudentLevel { get; set; }
    
                [XmlElement(ElementName = "StudentType")]
                public string StudentType { get; set; }
    
                [XmlElement(ElementName = "HasScholarship")]
                public string HasScholarship { get; set; }
    
                [XmlElement(ElementName = "Action")]
                public string Action { get; set; }
            }
