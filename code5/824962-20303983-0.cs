    class StringListConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;
            var strings = value as IEnumerable<string>;
            if (strings != null)
            {
                result = string.Join(", ", strings);
            }
            return result;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
