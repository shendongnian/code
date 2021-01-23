    public abstract class Bundled<T>
    {
        protected Tuple<T, object> _bundle;
        public abstract T Value { get; set; }
        //... Everything else
    }
    public class BundledClass<T> : Bundled<T> where T : class
    {
        public sealed override T Value
        { 
            get { return _bundle == null ? null : _bundle.Item1; }
            set { _bundle = new Tuple<T, object>(value, internalObj); }
        }
    }
    public class BundledPrimitive<T> : Bundled<T?> where T : struct
    {        
        public sealed override T? Value
        { 
            get { return _bundle == null ? null : _bundle.Item1; }
            set { _bundle = new Tuple<T?, object>(value, internalObj); }
        }
    }
