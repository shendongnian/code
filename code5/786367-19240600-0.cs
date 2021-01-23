    public class UsageIndicator
    {
        public string Value { get; private set; }
        public bool IsUsed { get; private set; }
        public UsageIndicator(string value, bool isUsed)
        {
            Value = value;
            IsUsed = isUsed;
        }
        public override string ToString()
        {
            return Value;
        }
    }
