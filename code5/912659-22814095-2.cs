    public class Blog
    {
        [Key()]
        public int Id { get; set; }
        [MaxLength(256)]//Need to limit size of column for clustered indexes
        public string Title { get; set; }
        [Index("IdAndRating", IsClustered = true)]
        public int Rating { get; set; }
    }
