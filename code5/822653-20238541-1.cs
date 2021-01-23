    public static class FactoryClass
    {
        private static Core obj = null;
        private static readonly object padLock = new object();
        
        public static Core GetInstance()
        {
            if (obj == null)
            {
              lock (padLock)
              {
                    obj = new Core();
              }
            }
            return obj;
          }
    }
