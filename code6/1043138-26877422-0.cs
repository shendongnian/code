    [Serializable()]
    public partial class StringWrapper
    {
        [XmlAttribute("alt-name")] 
        public string altname { get; set; }
        [XmlText()] 
        public string Value { get; set; }
        public static implicit operator string (StringWrapper sw) { return sw.Value; }
        public static implicit operator StringWrapper (string s) { 
          return new StringWrapper() { altname = "someotherstring", Value = s };
        }
    }
