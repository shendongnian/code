    public class Comment
    {
        public virtual int Id { get; set; }
        public string Body { get; set; }
        public DateTime AddDate { get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual int LikeCount { get; set; }
        public int? ParentId { get; set; }
        public virtual Comment Parent { get; set; }
        public ICollection<Comment> Children { get; set; }
        public virtual Member Member { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
    }
    public class Member
    {
        public int Id { get; set; }
    }
