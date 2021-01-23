    public class Post
    {
        public virtual int Id { get; set; }
        [Display(Name = "Post")] 
        public virtual string PostText { get; set; }
        public virtual IList<Comment> Comments { get; protected set; }
        public Post()
        {
             Comments = new List<Comment>();
        }
        public virtual void AddComment(Comment comment)
        {
            if (!Comments.Contains(comment))
            {
                 Comments.Add(comment);
                 comment.Post = this;
            }
        }
    }
