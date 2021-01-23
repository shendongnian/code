    [DataContract]
    public class ViewItem
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
    }
