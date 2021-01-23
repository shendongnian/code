        [DataContract]
        public class MyDynamicClass : DynamicObject
        {
            [DataMember]
            public string MyNormalProperty { get; set; }
        }
