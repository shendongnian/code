    public abstract class JsonTypeWrapper
    {
        protected JsonTypeWrapper() { }
        [IgnoreDataMember]
        public abstract object ObjectValue { get; }
        public static object CreateWrapper<T>(T value)
        {
            if (value == null)
                return new JsonTypeWrapper<T>();
            var type = value.GetType();
            if (type == typeof(T))
                return new JsonTypeWrapper<T>(value);
            // Return actual type of subclass
            return Activator.CreateInstance(typeof(JsonTypeWrapper<>).MakeGenericType(type), value);
        }
    }
    [DataContract]
    public sealed class JsonTypeWrapper<T> : JsonTypeWrapper
    {
        public JsonTypeWrapper() : base() { }
        public JsonTypeWrapper(T value) : base()
        {
            this.Value = value;
        }
        public override object ObjectValue
        {
            get { return Value; }
        }
        [DataMember]
        public T Value { get; set; }
    }
