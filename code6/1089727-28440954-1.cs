    public class MyDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
    }
    public class DictionaryContainer
    {
        public DictionaryContainer()
        {
            this.Values = new MyDictionary<string, string>();
        }
        public IDictionary<string, string> Values { get; set; }
    }
    public static class TestClass
    {
        public static void Test()
        {
            var container = new DictionaryContainer();
            container.Values["one"] = "first";
            container.Values["two"] = "second";
            container.Values["three"] = "third";
            Debug.Assert(container.Values.GetType() == typeof(MyDictionary<string, string>)); // No assert
            var json = JsonConvert.SerializeObject(container, Formatting.Indented);
            var container2 = JsonConvert.DeserializeObject<DictionaryContainer>(json);
            Debug.Assert(container.Values.GetType() == container2.Values.GetType());// No assert
        }
    }
