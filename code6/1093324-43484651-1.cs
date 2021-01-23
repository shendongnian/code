    public class DateTimeOffsetConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(DateTimeOffset))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var s = value as string;
            if (s != null)
            {
                if (s.EndsWith("Z", StringComparison.OrdinalIgnoreCase))
                {
                    s = s.Substring(0, s.Length - 1) + "+0000";
                }
                DateTimeOffset result;
                if (DateTimeOffset.TryParseExact(s, "yyyyMMdd'T'HHmmss.FFFFFFFzzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    return result;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
