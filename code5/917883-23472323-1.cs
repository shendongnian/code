    public static class ModelExtensions
    {
         // special case for string, because default(string) != string.empty 
         public static string SafeGetString<T>(this T obj, Func<T, string> selector)
         {
              try {
                  return selector(obj) ?? string.Empty;
              }
              catch(Exception){
                  return string.Empty;
              }
         }
         public static TResult SafeGet<T,TResult >(this T obj, Func<T, TResult> selector)
         {
              try {
                  return selector(obj) ?? default(TResult);
              }
              catch(Exception){
                  return default(TResult);
              }
         }
    }
