        [XmlInclude(typeof(XMLTagValue)), XmlInclude(typeof(XMLValue))]
        public class XMLTagDataSection
        {
            [XmlElement("Offset")]
            public int XML_Offset        { get; set; }
            [XmlElement("Type")]
            public EnuDataType XML_type  { get; set; }
            public object Tag_Value      { get; set; }
        }
        
        public class XMLVariable
        {
            [XmlElement("Variable", IsNullable = false)]       
            public int   Variable { get; set; }
        }
        public class XMLValue
        {
            [XmlElement("Value", IsNullable = false)]
            public string XML_Value      { get; set; }
        }
