    [JsonConverter(typeof(DictionaryWrapperConverter))]
    class MyWrapper : IEnumerable
    {
        Dictionary<string, string> values = new Dictionary<string, string>();
        public void Add(string key, string value)
        {
            values.Add(key, value);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }
