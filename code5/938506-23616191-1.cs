    public class Singleton<T> where T : class, new()
    {
        #region Constructors
    
        protected Singleton()
        { }
    
        #endregion Constructors
    
        #region Properties
        private static readonly object instanceLock = new object();
        private static T instance;
    
        public static T GetInstance()
        {
            if (instance == null)
            {
                lock(this.instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new T(); 
                    }
                }
            }
    
            return instance;
        }
    
        public static void ClearInstance()
        { instance = null; }
    
        #endregion Properties
    }
