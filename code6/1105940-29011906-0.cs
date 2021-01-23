    public class Post
    {
        public int PostId { get; set; }
    
        [Required]
        public string Title { get; set; }
    
        [NotMapped]
        public bool IsLikedByCurrentUser {get;set;}
    
        public virtual ICollection<Comment> CommentsAssociated { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<PostBookmark> PostBookmarks { get; set; }
    }
