    public delegate bool TryParser<TResult>(string s, out TResult result);
    public static class FunExtensions
    {
      public static T TryParse<T>(this string str, TryParser<T> tryParser)
      {
        T outResult;
        tryParser(str, out outResult);
        return outResult;
      }
    }
