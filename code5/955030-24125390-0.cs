    [DataContract]
    class MyObject
    {
        [DataMember(Name = "x")]
        public string X { get; set; }
        
        [DataMember(Name = "y")]
        public int Y { get; set; }
    
        [IgnoreDataMember]
        public double Z { get; set; }
    }
