    public class Sub2ClassField
    {
        [XmlAttribute("field")]
        public string strField { get; set; }
        public bool ShouldSerializestrField()
        {
            return !string.IsNullOrEmpty(strValue);
        }
        [XmlAttribute("value")]
        public string strValue { get; set; }
        public bool ShouldSerializestrValue()
        {
            return !string.IsNullOrEmpty(strValue);
        }
        public Sub2ClassField()
        {
            strField = "";
            strValue = "";
        }
        public override string ToString()
        {
            return strValue;
        }
    }
