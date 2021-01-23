    public class ClassifiedsViewModel
    {
      public ClassifiedsViewModel()
      {
         Comments = new List<ClassifiedsComments>();
      }
 
      public Classifieds Classifieds { get; set; }
      public List<ClassifiedsComments> Comments { get; set; }
    }
