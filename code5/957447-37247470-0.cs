    public sealed class WhiteSpaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;
            if (str == null) return value;
            return str.Replace(" ", "·");
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;
            if (str == null) return value;
            return str.Replace("·", " ");
        }
    }
