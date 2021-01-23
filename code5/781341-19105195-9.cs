    public static class BaseClass<T,F> where T : IPublicDictionary<F>, new()
    {
     public static String ToString(F argument)
     {
      IPublicDictionary<F> t = new T();
      return t.PublicDictionary.First(d => Comparer<F>.Equals((F)d.Value, argument)).Key;
     }
     public static F FromString(string argument)
      {
       IPublicDictionary<F> t = new T();
       return t.PublicDictionary[argument];
      }
    }
