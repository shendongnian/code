    public static class ModelExtensions
    {
         public static string SafeGet<T>(this T obj, Func<T, string> selector)
         {
              return selector(obj) ?? string.Empty;
         }
    }
