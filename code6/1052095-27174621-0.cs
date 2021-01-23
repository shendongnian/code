        [DataContract]
        class IttResponse
        {
            [DataMember(Name = "response")]
            public int Response { get; set; }
    
            [DataMember(Name = "result")]
            public string IttPackage Result{ get; set; }
        }
