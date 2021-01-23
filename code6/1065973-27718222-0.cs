    public class DynamicDictionary
    {
        private IDictionary<string, string> dictionaryKeyValuePair;
        
        public DynamicDictionary()
        {
            dictionaryKeyValuePair = new Dictionary<string, string>();
        }
        public void AddKeyValuePair(string key, string value)
        {
            dictionaryKeyValuePair.Add(key, value);
        }
        public string GetValueByKeyName(string Key)
        {
            string value = "";
            foreach (var keyValuePair in dictionaryKeyValuePair)
            {
                if (keyValuePair.Key.Equals(Key, StringComparison.CurrentCultureIgnoreCase))
                {
                    return keyValuePair.Value;
                }
            }
            return value;
        }
    }
