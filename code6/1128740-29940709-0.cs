    [AttributeUsage(AttributeTargets.Property)]
    public class TextSampleAttribute : Attribute
    {
        public string Value { get; set; }
        public TextSampleAttribute(string value)
        {
            Value = value;
        }
    }
