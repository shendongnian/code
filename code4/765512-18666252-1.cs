    public static class Singleton<T> where T : new()
    {
        private static T _instance;
    
        public static T GetInstance()
        {
            return _instance ?? (_instance = new T());
        }
    }
