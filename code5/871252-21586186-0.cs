    public class DictionaryFinder : IFinder
    {
        private Dictionary<string, string> dictionary;
        public DictionaryFinder(Dictionary<string, string> dictionary)
        {
            this.dictionary = dictionary;
        }
        public bool ContainsKey(string key)
        {
            return dictionary.ContainsKey(key);
        }
        public string this[string key]
        {
            get { return dictionary[key]; }
            set { dictionary[key] = value; }
        }
    }
