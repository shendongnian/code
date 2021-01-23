    public static class MyExtensions
    {
         public static bool IsEmptyOrWhiteSpace(this string source)
         {
              return source.Trim(' ').Length == 0 || source.Length == 0;
         }
    }
