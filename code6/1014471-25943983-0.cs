    public sealed class MyDictionary<TKey,TValue>
    {
        private static volatile Dictionary<TKey, TValue> instance;
        private static object syncRoot = new object();
        public static Dictionary<TKey, TValue> Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Dictionary<TKey, TValue>();
                    }
                }
                return instance;
            }
        }
    }
