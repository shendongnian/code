    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static object _syncRoot = new Object();
        public static T Instance
        {
            get
            {
                var instance = _instance;
                if (instance == null)
                {
                    lock (_syncRoot)
                    {
                        instance = Volatile.Read(ref _instance);
                        if (instance == null)
                        {
                            instance = new T();
                        }
                        Volatile.Write(ref _instance, instance);
                    }
                }
                return instance;
            }
        }
    }
