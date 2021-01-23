    [DataContract]
    public class Utility
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Rate Rate { get; set; }
    }
    [DataContract]
    public class Rate
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Sector { get; set; }
        [DataMember]
        public string Metering { get; set; }    
        [DataMember]
        public bool IsDefault { get; set; }
        [DataMember]
        public bool IsTimeofUse { get; set; }    
    }
