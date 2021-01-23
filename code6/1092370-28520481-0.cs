    public interface Parameter
    {
        object Value { get; set; }
    }
    
    public class Parameter<T> : Parameter
    {
        public T Value { get; set; }
    
        // Explicit interface implementation
        object Parameter.Value
        {
            get { return Value; }
            set { Value = (T)value; }
        }
    }
