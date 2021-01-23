    public class Movie
    {
        public string Name { get; set; }
        public int SumOfAllRatings { get; set; }
    
        public virtual Collection<Rating> Ratings { get; set; }
    }
    
    public class Rating
    {
        public virtual Movie Movie { get; set; }
        public int Rating { get; set; }
    
    }
