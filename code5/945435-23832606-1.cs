    public class MyTypeConverter : TypeConverter
    {
        public const int MaxLength = 10;
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return Truncate(value as string, MaxLength);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return Truncate(value as string, MaxLength);
        }
        private static string Truncate(string value, int maxLength)
        {
            if (value == null)
                return null;
            
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
