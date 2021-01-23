        public static class ModelExtensions
        {
             // special case for string, because default(string) != string.empty 
             public static string SafeGet<T>(this T obj, Func<T, string> selector)
             {
                  try {
                      return selector(obj) ?? string.Empty;
                  }
                  catch(Exception){
                      return string.Empty;
                  }
             }
       }
