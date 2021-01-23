    public class KeyPairs
    {
        public string Key { get; set; }
        public double Value { get; set; }
    }
    var keyValuePairs = new List<KeyPairs>
    {
        new KeyPairs {Key = "a", Value = 30},
        new KeyPairs {Key = "b", Value = 20}
    };
    double max = keyValuePairs.Max(pairs => pairs.Value);
