    public class MovieModel
        {
          public int MovieId {get; set;}
          public string MovieName {get; set;}
          public IEnumerable<Comment> MovieComments {get; set;}
        }
