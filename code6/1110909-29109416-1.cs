    public class StringListConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(
            ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return ((string)value).Split(',');
        }
    }
    ...
    [TypeConverter(typeof(StringListConverter))]
    public IList<string> FileTypeList
    {
        get { return (IList<string>)GetValue(FileTypeListProperty); }
        set { SetValue(FileTypeListProperty, value); }
    }
