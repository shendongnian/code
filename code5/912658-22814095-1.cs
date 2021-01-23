    public class Blog
    {
        [Index("IdAndRating", 1)]
        public int Id { get; set; }
     
        public string Title { get; set; }
     
        [Index("RatingIndex")]
        [Index("IdAndRating", 2, IsClustered = true)]
        public int Rating { get; set; }
     
        public virtual ICollection<Post> Posts { get; set; }
    }
