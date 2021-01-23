    public class Twitter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<EntityC> Lines { get; set; }
    }
    public class Reddit : Twitter
    {
        // leave this empty
    }
