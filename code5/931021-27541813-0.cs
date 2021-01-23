    [DataContract]
    public class GridProperties<T>
    {
        [DataMember]
        public List<T> Rows { get; set; }
    
        [DataMember]
        public int Records { get; set; }
    
        [DataMember]
        public int Total { get; set; }
    
        [DataMember]
        public int Page { get; set; }
    }
