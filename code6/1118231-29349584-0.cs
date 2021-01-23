    public class InvertBooleanToVisibilityConverter : IValueConverter
    {       
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            var boolValue = (bool)value;            
            return boolValue ? Visibility.Collapsed : Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
