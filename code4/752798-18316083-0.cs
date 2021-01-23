    public class Comment
    {
        // snip - see above
    
        public int UserId {get; set;}
        public virtual UserProfile User { get; set; }
    }
