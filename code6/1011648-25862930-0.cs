    public class Posts
    {
        public virtual int Id { get; set; }
        public virtual string Post { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
    public class Comment
    {
         public virtual int Id { get; set; }
         public virtual Post Post { get; set; }
         public virtual string CommentText { get; set; }
    }
