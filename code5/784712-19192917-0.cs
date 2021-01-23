    public abstract class Base<T>
        where T : BaseType
    {
        public abstract DataType Type { get; }
        
        public abstract T Value { get; set; }
    }
