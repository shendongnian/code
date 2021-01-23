    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public class EnumValueDescriptionAttribute : Attribute
    {
        public string StringValue
        {
            get;
            protected set;
        }
    
        public EnumValueDescriptionAttribute(string value)
        {
            this.StringValue = value;
        }
    }
