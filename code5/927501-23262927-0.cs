    [Serializable]
    public class Feed
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public User user  { get; set; }
        public string created_at 
        { 
            get { return CreatedAt.ToString(FORMAT); }
            set { CreatedAt = DateTime.ParseExact(value, "ddd MMM dd HH:mm:ss zzzz yyyy", CultureInfo.InvariantCulture); }
        }
        [NotSerialized]
        public DateTime CreatedAt { get; set; }
    }
