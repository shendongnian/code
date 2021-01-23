    [TypeConverter(typeof(CountryCodeConverter))]
    public class CountryCode
    {
        ...
    }
    public class CountryCodeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) { return true; }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string && value != null)
            {
                return (CountryCode)((string)value);
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
