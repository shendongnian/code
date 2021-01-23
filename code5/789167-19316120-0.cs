    public class KeyValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Test
    {
        public IEnumerable<KeyValue> KV { get; set; }
    }
