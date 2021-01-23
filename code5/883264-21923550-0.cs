    public class ClassifiedsDetailViewModel
    {
      public ClassifiedsDetailViewModel()
      {
          ClassifiedsComments = new ClassifiedsComments();
      }
      public Classifieds Classifieds { get; set; }
      public ClassifiedsComments ClassifiedsComments { get; set; }
    }
    
