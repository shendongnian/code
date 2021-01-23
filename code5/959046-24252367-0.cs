    public class Sempre
    {
        private Dictionary<string, string> _values = new Dictionary<string, string>();
    
        public string this[string key]
        {
            get { return _values[key]; }
            set { _values[key] = value; }
        }
    }
