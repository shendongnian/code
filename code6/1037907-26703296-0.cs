    public class SomeRepository
    {
       private static SomeRepository _instance;
       public static SomeRepository Instance
       {
           get 
           {
               return _instance ?? (_instance = new SomeRepository());
           }
       }
    }
