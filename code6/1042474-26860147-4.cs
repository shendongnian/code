    interface IPropertySlot
    {
        bool IsDirty { get; }
        void ResetIsDirty();
        object UntypedValue { get; }
    }
    class PropertySlot<T>:IPropertySlot 
    {
        public T Value { get; private set; }
        public bool SetValue(T value)
        {
            if (!Equals(_value, Value))
            {
                Value = value;
                IsDirty = true;
                return true;
            }
            return false;
        }
        public bool IsDirty { get; private set; }
        public void ResetIsDirty()
        {
            IsDirty = false;
        }
        public object UntypedValue
        {
            get { return Value; }
        }
    }
