    public class EnumToDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var enumValue = value as Enum;
            return enumValue == null ? DependencyProperty.UnsetValue : enumValue.GetDescriptionFromEnumValue();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
