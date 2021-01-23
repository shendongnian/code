    class TextConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0}:{1}", values[0], values[1]);
        }
        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return ((string)value).Split(':');
        }
    }
