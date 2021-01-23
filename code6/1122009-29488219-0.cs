    public class Row
        {
            [XmlElement("field_1")]
            public String Field1
            {
                get;
                set;
            }
    
            [XmlElement("field_2")]
            public int Field2
            {
                get;
                set;
            }
        }
    
    public class Parameters
        {
            [XmlArray("rows")]
            [XmlArrayItem("row")]
            public List<Row> rows = new List<Row>();
        }
    
    
    
    [XmlRoot(ElementName = "AAA")]
    public class Base
        {
            [XmlAttribute("attr1")]
            public String Attribute1 = "6687";
    
            [XmlAttribute("attr2")]
            public String Attribute2 = "65";
    
            [XmlElement("params")]
            public List<Parameters> parameters = new List<Parameters>();
        }
