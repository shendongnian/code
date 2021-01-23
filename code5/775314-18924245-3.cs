    public class BoolToVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var checked= (bool)value;
            return checked ? Visibility.Visible : Visibility.Collapsed;
        }
    }
