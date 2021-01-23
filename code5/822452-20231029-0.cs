        [DataContract(Namespace = "DataContracts")]
        public class Foo
        {
            [DataMember]
            public string First;
            [DataMember]
            public string Second;
            [DataMember]
            public string Third;
        }
        [DataContract(Namespace = "DataContracts")]
        public class Bar
        {
            [DataMember]
            public string First;
            [DataMember]
            public string Second;
            [DataMember]
            public Foo[] ManyFoos;
        }
        [DataContract(Namespace = "DataContracts")]
        public class Root
        {
            [DataMember]
            public string First;
            [DataMember]
            public string Second;
            [DataMember]
            public Bar[] ManyBars;
        }
