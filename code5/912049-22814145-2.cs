     public IEnumerable<MovieSummary> GetAll()
     {
         return unit.DbSet<Movie>();
     }
     // All properties needed in summarized representation
     public class MovieSummary
     {
         public int MovieID { get; set; }
         public string   Name { get; set; }
         public string   Description { get; set; }
         public bool HasLike { get; set; }
         // Other calculated properties
     }
