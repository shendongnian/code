        [XmlRoot(ElementName = "head")]
        public class Head
        {
            [XmlElement]
            public coordinate coordinates { get; set; }
        }
        public class coordinate { }
