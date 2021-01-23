    public class Thing
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Key + "--" + Value;
        }
    }
