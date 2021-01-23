    using System.Xml.Serialization;
    
    namespace PsihoXXX
    {
        [XmlRoot("Tag")]
        public class Tag
        {
            [XmlElementAttribute("SomeType")] 
            public SomeType[] someType;
    
            public Tag()
            {
            }
        }
    
        public class SomeType
        {
            [XmlAttribute("id")] 
            public int id;
    
            [XmlElementAttribute("ResourceDescription")] 
            public ResourceDescription[] resourceDescription;
    
            public SomeType()
            {}
        }
    
        public class ResourceDescription
        {
            [XmlAttribute("entityId")] 
            public int entityId;
    
            [XmlElementAttribute("Property")] 
            public Property[] property;
    
            public ResourceDescription()
            {
            }
        }
    
        public class Property
        {
            [XmlAttribute("columnName")] 
            public string columnName;
    
            [XmlElement("Value")] 
            public string value;
    
            public Property()
            {
            }
        }
    }
