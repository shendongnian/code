    public class Foo
    {
        private ConcurrentDictionary<long, object> dictionary = 
            new ConcurrentDictionary<long, object>();
        private void EditCheck(long checkid)
        {
            var key = dictionary.GetOrAdd(checkid, new object());
            lock (key)
            {
                //Do stuff with key
            }
        }
    }
