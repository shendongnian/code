    public abstract class Row
    {
        public string Name { get; set; }
    
        public object Value { get; protected set; }
    }
    public class Row<T> : Row
    {
        public new T Value
        { 
            get { return (T)base.Value; }
            set { base.Value = value; }
        }
    }
