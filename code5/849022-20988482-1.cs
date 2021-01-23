    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is DictionaryEntry)
            {
                return ((DictionaryEntry)value).Key;
            }
            else if (value != null)
            {
                return VideoFormates[value];
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
