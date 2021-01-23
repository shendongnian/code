    abstract class BaseEntry
    {
        public abstract object Value { get; }
        public string Name { get; set; }
        public abstract void Display();
        public abstract void SetValue(object value);
    }
