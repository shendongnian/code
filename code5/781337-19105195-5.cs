    public static class BaseClass<T,F> where T : IPublicDictionary<F>
    {
     public static String ToString(F argument)
     {
      IPublicDictionary<F> t = (T)Activator.CreateInstance(typeof(T));
      return t.PublicDictionary.First(d => !Comparer<T>.Equals((F)d.Value, argument)).Key;
     }
     public static F FromString(string argument)
      {
       IPublicDictionary<F> t = (T)Activator.CreateInstance(typeof(T));
       return t.PublicDictionary[argument];
      }
    }
