    using System;
    using System.Collections.Concurrent;
    
    namespace YourNamespace
    {
        public static class ObjectCache
        {
            private readonly static ConcurrentDictionary<string, object> Data = new ConcurrentDictionary<string, object>();
    
            public static void SetValue(string key, object value)
            {
                Data[key] = value;
            }
    
            public static object GetValue(string key)
            {
                object t;
                if (!Data.TryGetValue(key, out t))
                    return null;
                return t;
            }
    
            public static void Purge()
            {
                Data.Clear();
            }
        }
    }
