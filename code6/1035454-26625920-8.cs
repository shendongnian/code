    // define a common interface (Value is an object)
    interface IXmlArg
    {
        string Name { get; }
        Type Type { get; }
        object Value { get; set; }
    }
    // I used generics to get type safety and "free" type T information 
    class XmlArg<T> : IXmlArg
    {
        public XmlArg(string name, Action<T> setter, Func<T> getter)
        {
            _name = name;
            _setter = setter;
            _getter = getter;
        }
        private readonly string _name;
        public string Name { get { return _name; } }
        public Type Type { get { return typeof(T); } }
        private readonly Func<T> _getter;
        private readonly Action<T> _setter;
        public object Value
        {
            get { return (object)_getter(); }
            set { _setter((T)value); }
        }
    }
