    class Post {
        public int postid { get; set; }
        public virtual ICollection<comment> comment { get; set; }
        public int CommentCount
        {
            get 
            { 
                return comment.Count();
            }
        }
    }
