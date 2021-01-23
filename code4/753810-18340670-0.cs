    [XmlType("PropertiesMapping")]
    public class PropertyMapping
    {
        public PropertyMapping()
        {
            Properties = new List<Property>();
        }
        
        [XmlElement("Property")]
        public List<Property> Properties { get; set; }
    }
    
    public class Property
    {
        public Property()
        {
            Mappings = new List<Mapping>();
        }
    
        [XmlElement("WEB_Class")]
        public string WebClass { get; set; }
        
        [XmlElement("COM_Class")]
        public string ComClass { get; set; }
        
        [XmlArrayItem("Map")]
        public List<Mapping> Mappings { get; set; }
    }
    
    public class Mapping
    {
        [XmlElement("WEB_Property")]
        public string WebProperty { get; set; }
        
        [XmlElement("COM_Property")]
        public string ComProperty { get; set; }
    }
