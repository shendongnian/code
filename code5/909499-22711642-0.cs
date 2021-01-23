    [DataContract]
        public class Request
        {
            [DataMember, XmlAttribute]
            public string Source { get; set; }
            [DataMember]
            public MyData MyData { get; set; }
        }
        [DataContract]
        public class MyData
        {
            [DataMember, XmlAttribute]
            public string Identifier { get; set; }
            [DataMember, XmlAttribute]
            public double Value { get; set; }
            [DataMember]
            public List<Data> Datum { get; set; }
        }
        [DataContract]
        public class Data
        {
            [DataMember, XmlAttribute]
            public double Value { get; set; }
        }
