    class Example
    {
        private object cacheLock;
        public static void Load()
        {
            // . . .
            lock (cacheLock)
            {
                CacheTable = (ThreadSafeDictionary<String, 
                    ThreadSafeDictionary<Object, Object>>)CacheTableTmp.Clone();
            }
        }
