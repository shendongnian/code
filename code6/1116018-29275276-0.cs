    [DataContract]
    public class AddFriendRequest
    {
        [DataMember(Name="MY-TOKEN")]
        public string token { get; set; }
        [DataMember]
        public string uuid { get; set; }
    } 
