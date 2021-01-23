     public class Widget
        {
            [XmlAttribute]  
            public string Name;
            [XmlElement(IsNullable=true)]
            public string Value;       
        } 
