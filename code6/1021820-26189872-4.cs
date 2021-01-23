    public static class ListExtensions
    {
       public static bool ElementIsDefined<T>(this List<T> list, int index)
       {
           if (index < 0 || index >= list.Count)
               return false;
    
           var element = list[index];
           var type = typeof (T);
           if (Nullable.GetUnderlyingType(type) != null)
           {
               if (element is bool?)
                   return (element as bool?).Value;
               return element != null;
           }
    
           var defaultValue = default(T);
           // Use default(T) to actually get a value to check against.
           // Using the below line to create the default when T is "object" 
           // causes a false positive to be returned.
           return !EqualityComparer<T>.Default.Equals(element, defaultValue);
       }
    }
