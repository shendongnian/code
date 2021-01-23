    public interface IKnownValueDefinition<out T> 
    {
        public string Key { get; }
        public T DefaultValue { get; }
    }
    public class KnownValueDefinition<T> : IKnownValueDefinition<T>
    {
        // .. private members excluded for brevity
        public string Key { get { return _key; } }
        public T DefaultValue { get { return _defaultValue; } }
    }
