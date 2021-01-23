    public class StringValueAttribute : Attribute
    {
        private string _value;
        public StringValueAttribute(string value)
        {
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
        public static string GetStringValue(Enum value)
        {
            Type type = value.GetType();
            FieldInfo fi = type.GetRuntimeField(value.ToString());
            return (fi.GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault() as StringValueAttribute).Value;
        }
    }
