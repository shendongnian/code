     [Serializable, XmlRoot("patient")]
        public partial class patient
        {
            [XmlElement("pr")]
            public patientPR[] pr { get; set; }
            [XmlElement("ad")]
            public patientAD[] ad { get; set; }
        }
    
        [Serializable, XmlType("pr")]
        public partial class patientPR
        {
            [XmlElement("fname")]
            public string fname { get; set; }
            [XmlElement("lname")]
            public string lname { get; set; }
            [XmlElement("id")]
            public int id { get; set; }
        }
    
        [Serializable, XmlType("ad")]
        public partial class patientAD
        {
            [XmlElement("id")]
            public int id { get; set; }
            [XmlElement("streetnumber")]
            public string streetnumber { get; set; }
            [XmlElement("city")]
            public string city { get; set; }
            [XmlElement("state")]
            public string state { get; set; }
            [XmlElement("zip")]
            public ushort zip { get; set; }
        }
