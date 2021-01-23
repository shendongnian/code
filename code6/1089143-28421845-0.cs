    [DataContract]
    public class Detail
    {
        [DataMember(Name="text")]
        public string Text { get; set; }
        [DataMember(Name="createdTime")]
        public long CreatedTimeStamp { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember(Name="abcDetails")]
        public List<Detail> Details { get; set; }
    }
