    class BoolTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof (bool))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is string)
            {
                var s = value as string;
                if (string.IsNullOrEmpty(s))
                    return false;
                switch (s.Trim().ToUpper())
                {
                    case "TRUE":
                    case "YES":
                    case "1":
                    case "-1":
                        return true;
                    default:
                        return false;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
