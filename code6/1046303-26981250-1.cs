    public class ArticleFormViewModel
    {
      [AllowHtml]
      public string Contents { get; set; }
      
      [DataType(DataType.Upload)]
      public HttpPostedFileBase ImageFile { get; set; }
    }
    public class Image
    {
      public int ImageID { get; set; }
      ...
    }
    public class Article
    {
      public int ArticleID { get; set; }
      ...
    }
