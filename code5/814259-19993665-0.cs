    public class MovieModel
    {
      public int MovieId {get; set;}
      public string MovieName {get; set;}
      public IEnumerable<CommentModel> MovieComments {get; set;}
    }
    public class CommentModel
    {
      public int CommentId {get; set;}
      public int CommentText {get; set;}
    }
 
