    public class Foo
    {
        private ConcurrentDictionary<string, object> locks =
            new ConcurrentDictionary<string, object>();
        public string Produce(string key)
        {
            lock (locks.GetOrAdd(key, new object()))
            {
                //TODO do whatever
                return "";
            }
        }
    }
