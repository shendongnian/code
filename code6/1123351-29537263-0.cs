    public class PropertyChangingEventArgs : EventArgs
    {
        public PropertyChangingEventArgs()
        {
        }
        public PropertyChangingEventArgs(string propName, object oldValue, object newValue)
        {
            PropertyName = propName;
            OldValue = oldValue;
            NewValue = newValue;
        }
        public string PropertyName { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
