    public sealed class NoOpConverter : IValueConverter
    {
        public static readonly NoOpConverter Instance = new NoOpConverter();
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return value;
        }
    }
