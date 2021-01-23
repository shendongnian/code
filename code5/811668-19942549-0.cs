        [DataContract]
        public class Info
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "description")]
            public string Description { get; set; }
        }
