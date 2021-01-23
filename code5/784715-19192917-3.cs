    public abstract class Base
    {
        public abstract DataType Type { get; }
    }
    
    public abstract class Base<T> : Base
        where T : BaseType
    {
        public abstract T Value { get; set; }
    }
