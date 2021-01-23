    public class CommentVM
    {
      public string Comment { get; set; }
      public string CommentAuthor { get; set; }
      public DateTime CommentDate { get; set; }
    }
    public class PostVM
    {
      public string PostTitle { get; set; }
      public string PostContent { get; set; }
      public string PostAuthor { get; set; }
      public DateTime PostDate { get; set; }
      List<CommentVM> Comments { get; set; }
    }
