    public class RootObject
    {
        public List<List<DeltaInfo>> entries { get; set; }
    }
    public class DeltaInfo
    {
        [DataMember]
        public string Path { get; internal set; }
     
        [DataMember]
        public PathInfo MetaData { get; internal set; }
     }
