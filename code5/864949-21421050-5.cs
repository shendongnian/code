    public class KnownValueDefinition<T> :
          IKnownValueDefinition
        , IKnownValueDefinition<T>
    {
        // .. private members excluded for brevity
        public string Key { get { return _key; } }
        public T DefaultValue { get { return _defaultValue; } }
    
        public KnownValueDefinition( string key, T DefaultValue )
        {
            //...construction logic
        }
    
        public IKnownValueDefinition<object> GetDefault()
        {
            return new KnownValueDefinition<object>( this._key, this._defaultValue );
        }
    }
    
    public interface IKnownValueDefinition
    {
        IKnownValueDefinition<object> GetDefault();
    }
    
    public interface IKnownValueDefinition<out T>
    {
        string Key { get; }
        T DefaultValue { get; }
    }
