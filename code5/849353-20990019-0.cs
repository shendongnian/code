    public abstract class Value { }
    public class StringValue : Value
    {
        public string Value { get; private set; }
        public StringValue(string value)
        {
            this.Value = value;
        }
    }
    public class DictionaryValue : Value
    {
        public Dictionary<string, Value> Values { get; private set; }
        public DictionaryValue()
        {
            this.Values = new Dictionary<string, Value>();
        }
    }
