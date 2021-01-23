    [System.Xml.Serialization.XmlRoot(ElementName = "table")]        
    public class Table
    {
        [System.Xml.Serialization.XmlElement("row")]
        public Row[] Rows;
    }
    
    public class Row
    {
        public string V;
    }
