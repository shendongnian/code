    class ErrorInfo
    {
        public ErrorInfo(string value, string description)
        {
            Value = value;
            Description = description;
        }
        public string Value {get; private set;}
        public string Description {get; private set;}
    }
