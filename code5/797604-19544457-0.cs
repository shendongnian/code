    class TransformCollection
    {
       private Hashtable cache = new Hashtable();
       public void Add<T>(EntityTypeTransform<T> transform) where T : class
       {
          this.cache[typeof(T)] = itemToCache;
       }
       public bool Exists<T>()
       {
          return this.cache.ContainsKey(typeof(T));
       }
       public EntityTypeTransform<T> Get<T>()
       {
          if (!this.Exists<T>())
             throw new ArgumentException("No cached transform of type: " + typeof(T).Name);
          return this.cache[typeof(T)] as ExpressionComparer<T>;
       }
    }
