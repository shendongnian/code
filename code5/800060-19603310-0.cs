    class ConcreteAXLAPIService<T>
    {
      private Dictionary<string, T> servicePool;
    
      public T this[string id]
      {
        get
        {
            return servicePool[id];
        }
      }
    }
    
    
    class MyService<T>
    {
        private Dictionary<string, T> methodPool;
    
        public T this[string id]
        {
          get
          {
              return methodPool[id];
          }
        }
    }
