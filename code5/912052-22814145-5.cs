     public MovieDetails Get(int id)
     {
     }
     // All properties needed in detailled representation
     public class MovieDetails
     {
         public int MovieID { get; set; }
         public string   Name { get; set; }
         public string   Description { get; set; }
         public ICollection<MovieLikes> Likes { get; set; }
         // more
     } 
