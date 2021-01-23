    [DataContract]
    public class root
    {
        [DataMember]
        public long modifyDate { get; set; }
        [DataMember]
        public int summonerId { get; set; }
        [DataMember]
        public IEnumerable<champion> champions { get; set; }
    }
    [DataContract]
    public class champion
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public stats stats { get; set; }
    }
    
    [DataContract]
    public class stats
    {
        [DataMember]
        public int totalDeathsPerSession { get; set; }
        [DataMember]
        public int totalSessionsPlayed { get; set; }
    }
