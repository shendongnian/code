    public class Localization{
    
       [ThreadStatic]
       private static Localization _current;
    
       public static Current {
         get { _current = _current ?? new Localization(); return _current }
         set { _current = value; }
       }
    }
