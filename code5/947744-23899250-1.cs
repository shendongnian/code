    [DataContract]
    public class Delta
    {
        [DataMember(Name="entries")]
        public List<List<DeltaInfo>> entries { get; set; }
    }
    [DataContract]
    public class DeltaInfo
    {
        [DataMember]
        public string Path { get; internal set; }
     
        [DataMember]
        public PathInfo MetaData { get; internal set; }
     }
