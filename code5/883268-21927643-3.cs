    public class ClassifiedsViewModel
    {
      public ClassifiedsViewModel()
      {
         ClassifiedsComments = new ClassifiedsComments();
      }
 
      public Classifieds Classifieds { get; set; }
      public ClassifiedsComments ClassifiedsComments { get; set; }
    }
