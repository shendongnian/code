    public static class BaseClass
    {
     public static String ToString<F,T>(F argument) where T : IPublicDictionary<F>, new()
     {
      IPublicDictionary<F> t = new T();
      return t.PublicDictionary.First(d => Comparer<F>.Equals((F)d.Value, argument)).Key;
     }
     public static F FromString<T,F>(string argument) where T : IPublicDictionary<F>, new()
      {
       IPublicDictionary<F> t = new T();
       return t.PublicDictionary[argument];
      }
    }
