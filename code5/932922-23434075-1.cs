    public class Base<T> where T : new()
    {
       public static T Instance 
       {
           get
           {
               // do something to return new instance of inherit class from itself
               return new T();
           } 
       }
    }
