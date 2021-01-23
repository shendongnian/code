    public static class FactoryClass
    {
        private static Core obj = null;
        private static readonly object padLock = new object();
        
        public static Core GetInstance()
        {
            lock (padLock)
            {
              if (obj == null)
              {
                    obj = new Core();
              }
            }
            return obj;
          }
    }
