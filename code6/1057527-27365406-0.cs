        [XmlRoot("myroot", Namespace = "http://jeson.com/")]
        public class myrootNS
        {
            [XmlElement(Namespace = "")]
            public item[] item { get; set; }
        }
