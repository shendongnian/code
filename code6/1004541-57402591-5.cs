    [AttributeUsage(AttributeTargets.Field)]
    public class AlternativeValueAttribute : Attribute
    {
        public string JsonValue { get; set; }
        public string DbValue { get; set; }
        // and any other kind of alternative value you need...
    }
