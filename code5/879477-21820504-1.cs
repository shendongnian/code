        [Serializable()]
        public class SLVGeoZone
        {
            [XmlElement("id")]
            public string id { get; set; }
            [XmlElement("type")]
            public string type { get; set; }
            [XmlElement("name")]
            public string name { get; set; }
            [XmlElement("namesPath")]
            public string namespath { get; set; }
            [XmlElement("idsPath")]
            public string idspath { get; set; }
            [XmlElement("childrenCount")]
            public string childrencount { get; set; }
        }
