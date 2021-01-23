    public class TestDelegate
    {
        public T GetCulture<T>(string s) where T : class
        {
            return (new List<string> { s }) as T;
        }
        public T GetObject<T>(string key, Func<string, T> fn) where T : class
        {
            T foundItems = fn(key);
            return foundItems;
        }
        public void Test()
        {
            List<string> test = GetObject("abc", x => GetCulture<List<string>>(x));
        }
    }
