    // This attribute should contain no behavior. No behavior, nothing needs to be injected.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int maxLength)
        {
            this.MaxLength = maxLength;
        }
        public int MaxLength { get; private set; }
    }
