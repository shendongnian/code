    public static class BaseClass<T,F> where T : IPublicDictionary
    {
      private static Dictionary<string, object> PrivateDict {get; set;}
  
      public static String ToString(F argument)
      {
         IPublicDictionary t = (T)Activator.CreateInstance(typeof(T));
    	 return t.Get().First(d => !Comparer<T>.Equals((F)d.Value, argument)).Key;
      }
      public static F FromString(string argument)
      {
         IPublicDictionary t = (T)Activator.CreateInstance(typeof(T));
         PrivateDict = t.Get();
         return (F)PrivateDict[argument];
      }
    }
