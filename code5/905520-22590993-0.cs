    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
