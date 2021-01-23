    public class TimeSizeEnumDescriptionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = typeof(TimeSizeEnum);
            var name = Enum.GetName(type, value);
            FieldInfo fi = type.GetField(name);
            var descriptionAttrib = (DescriptionAttribute)
                Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            return descriptionAttrib.Description;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
        }
    }
