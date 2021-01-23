     [XmlRoot("CalculationInputs")]
      public class CalculationInputs
       {
    
      [XmlElement("Key")]
      public Key Key { get; set; }
    
      // InputList
      [XmlArray("array")]
      [XmlArrayItem("Input")]
      public List<Input> Input { get; set; }
      }
        public class Key
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }
            [XmlAttribute("Value")]
            public string Value { get; set; }
         }
        public class Input
        {
            [XmlAttribute]
            public string Name { get; set; }
            [XmlAttribute]
            public string Value { get; set; }
        }
