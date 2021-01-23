    public struct nString
    {
        public nString(string value)
            : this()
        {
            Value = value ?? "N/A";
        }
        public string Value
        {
            get;
            private set;
        }
        public static implicit operator nString(string value)
        {
            return new nString(value);
        }
        public static implicit operator string(nString value)
        {
            return value.Value;
        }
    }
    ...
    public nString val 
    { 
        get;
        set;
    }
    obj.val = null;
    string x = obj.val; // <-- x will become "N/A";
