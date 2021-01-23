    public abstract class Bundled<T>
    {
        private Tuple<T, object> _bundle;
        public T Value
        { 
            get { return _bundle == null ? default(T) : _bundle.Item1; }
            set { _bundle = new Tuple<T, object>(value, internalObj); }
        }
    }
