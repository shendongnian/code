    public static class MyExtensions
    {
    
        public static Dictionary<T1,T2> ToDictionary(this KeyValuePair<T1, T2> kvp)
        {
          var dict = new Dictionary<T1, T2>();
          dict.Add(kvp.Key, kvp.Value);
          return dict;
        }
    
    }
