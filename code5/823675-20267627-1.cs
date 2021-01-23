    public class BlogPost
    {
        public Guid Id { get; private set; }
        public virtual ICollection<Comment> Comments { get; private set; }
    }
    public class Comment
    {
        public Guid Id { get; private set; }
        public string Text { get; set; }
    }
