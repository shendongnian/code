    public class EntityColumn
    {
        private readonly Action<object> _setMethod;
        private readonly Func<object> _getMethod;
        public string Caption { get; private set; }
        public object Value
        {
            get { return _getMethod(); }
            set { _setMethod(value);}
        }
        internal EntityColumn(string caption, Action<object> setMethod, Func<object> getMethod)
        {
            _getMethod = getMethod;
            _setMethod = setMethod;
            Caption = caption;
        }
    }
