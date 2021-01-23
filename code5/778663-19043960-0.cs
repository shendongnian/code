    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Venue
    {
        public string Id { get; set; }
        public string Address { get; set; }
    }
    public class Message
    {
        public string Text { get; set; }
        [JsonProperty("fromId")]
        public string FromId { get; set; }
    }
