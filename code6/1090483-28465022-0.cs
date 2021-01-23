        [DataContract(Name = "result", Namespace = "")]
        public class Result
        {
            [DataMember(Name = "postcode", Order = 1)]
            public string Postcode { get; set; }
            [DataMember(Name = "geo", Order = 2)]
            public Geo Geo { get; set; }
        }
