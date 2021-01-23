    public class StripedBackgroundIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return Color.White;
            var index = ((ListView) parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            return index % 2 == 0 ? Color.White : Color.FromRgb(240, 240, 240);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
