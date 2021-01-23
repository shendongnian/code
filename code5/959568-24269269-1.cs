        [Serializable]
        [XmlRoot(ElementName = "ps")]
        public class ps
        {
            [XmlArray("disable_others")]
            [XmlArrayItem(typeof(Disable_Other), IsNullable = false)]
            public List<Disable_Other> Disable_Others { get; set; }
    
            public ps()
            {
                Disable_Others = new List<Disable_Other>();
            }
    
        }
    
        [Serializable]
        [XmlRoot("disable_other")]
        public class Disable_Other
        {
            [XmlElement("disablingitem")]
            public int DisablingItem { get; set; }
    
            //[XmlElement("to_disable")]
            [XmlArray("to_disable")]
            public string[] To_Disable { get; set; }
    
            [XmlElement("disable_value")]
            public byte Disable_Value { get; set; }
    
        }
