    ValueConverter="{StaticResource StringToDoubleConverterN3Key}"
    public class StringToDoubleConverterN3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value).ToString("N3").Replace('.', ',');
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
