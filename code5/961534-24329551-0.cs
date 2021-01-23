    sealed class VariableReference
    {
        public Func<object> Get { get; private set; }
        public Action<object> Set { get; private set; }
        public VariableReference(Func<object> getter, Action<object> setter)
        {
            Get = getter;
            Set = setter;
        }
    }
