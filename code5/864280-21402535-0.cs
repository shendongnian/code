    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
