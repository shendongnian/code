    class ReturnValue
    {
        public string Text;
        public int Value;
        public ReturnValue(string text, int value)
        {
            Text = text;
            Value = value;
        }
    }
    ReturnValue method()
    {
        // ...
        return new ReturnValue("", 12);
    }
