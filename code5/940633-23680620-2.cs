    public class TestDelegate
    {
        //You don't need generic here if you always return a list of string
        public List<string> GetCulture(string s) 
        {
            return new List<string> { s };
        }
        public T GetObject<T>(string key, Func<string, T> fn)
        {
            T foundItems = fn(key);
            return foundItems;
        }
        public void Test()
        {
            List<string> test = GetObject("abc", x => GetCulture(x));
        }
    }
