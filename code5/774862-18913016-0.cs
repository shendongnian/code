    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDescriptionAttribute :Attribute
    {
        private readonly string description;
        public string Description { get { return description; } }
        public EnumDescriptionAttribute(string description)
        {
            this.description = description;
        }
    }
    enum Foo
    {
        [EnumDescription("abc")]
        A,
        [EnumDescription("def")]
        B
    }
