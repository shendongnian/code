    public struct Failable<T>
    {
        public T Value { get; private set; }
        public string Text { get; private set; }
        public bool IsValid { get; private set; }
        public Failable(T value)
        {
            Value = value;
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                Text = converter.ConvertToString(value);
                IsValid = true;
            }
            catch
            {
                Text = String.Empty;
                IsValid = false;
            }
        }
        public Failable(string text)
        {
            Text = text;
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                Value = (T)converter.ConvertFromString(text);
                IsValid = true;
            }
            catch
            {
                Value = default(T);
                IsValid = false;
            }
        }
    }
