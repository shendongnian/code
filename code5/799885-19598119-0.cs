    public class ValidatedDictionary : IDictionary<string, int>
    {
        private Dictionary<string, int> _dict = new Dictionary<string, int>();
        protected virtual int Validate(int value)
        {
            return Math.Max(0, value);
        }
        public void Add(string key, int value)
        {
            _dict.Add(key, Validate(value));
        }
        public bool ContainsKey(string key)
        {
            return _dict.ContainsKey(key);
        }
        // and so on: anywhere that you take in a value, pass it through Validate
