    public class YourClass
    {
      public static string _string1 { get; set; }
      public static string _string2 { get; set; } 
      public static string  Example()
      {
        switch(_string1.length > _string2.length)
        {
         case true :
             return _string1;
             break;
         default : return _string2;
        }
      }
    }
