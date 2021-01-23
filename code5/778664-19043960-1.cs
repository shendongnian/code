    [JsonConverter(typeof(PostJsonConverter))]
    public class Post
    {
        public User User { get; set; }
        public Venue Venue { get; set; }
        public Message Message { get; set; }
    }
