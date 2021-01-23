    public class Singleton<T> where T : class
    {
        #region Constructors
    
        protected Singleton()
        { }
    
        #endregion Constructors
    
        #region Properties
    
        private static T instance;
    
        public static T GetInstance()
        {
            if (instance == null)
            {
                instance = typeof(T).InvokeMember(typeof(T).Name,
                BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic, null, null, null, CultureInfo.CurrentCulture) as T; 
            }
    
            return instance;
        }
    
        public static void ClearInstance()
        { instance = null; }
    
        #endregion Properties
    }
