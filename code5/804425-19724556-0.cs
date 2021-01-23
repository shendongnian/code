    public static class ExMethods
    {
       public static object First<T>(this ICollection<T> collection)
       {
         foreach (var x in collection)
         {
           return x;
         }
         //throw exception if colletion is empty
       }
    }
