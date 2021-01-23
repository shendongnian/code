    class CachedFunc<T>
    {
         private List<T> cache;
         private Func<int, T> original;
         private T Call(int n)
         {
            while (n >= cache.Count) cache.Add(original(cache.Count));
            return cache[n];
         }
         public static Func<int, long> Create(Func<int, T> original)
         {
             return new CachedFunc<T>() { cache = new List<T>(), original = original }.Call;
         }
    }
