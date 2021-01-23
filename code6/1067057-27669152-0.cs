    public static class MyStringExtensions
    {
         public static string RemoveAt(this string s, int index)
         {
             return s.Remove(index, 1);
         }
    }
