    public class ScopedValue
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
    public sealed class ConfigurationValue
    {
        public List<ScopedValue> ScopedValues { get; set; }
    }
