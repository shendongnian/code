    public class FooDataTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return base.GetStandardValues(context);
        }
    
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
    
            return (sourceType.Equals(typeof(Enum)));
        }
    
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType.Equals(typeof(String)));
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                return (ValidationDataType)Enum.Parse(typeof(ValidationDataType), value.ToString(), true);
            }
    
            return base.ConvertFrom(context, culture, value);
        }
    
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (!destinationType.Equals(typeof(string)))
                throw new ArgumentException("Can only convert to string", "destinationType");
    
            if (!value.GetType().BaseType.Equals(typeof(Enum)))
                throw new ArgumentException("Can only convert an instance of enum", "value");
    
            string name = value.ToString();
            object[] attr =
                value.GetType().GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);
    
            return (attr.Length > 0) ? ((DescriptionAttribute)attr[0]).Description : name;
    
        }
    
    }
