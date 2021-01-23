    public sealed class VisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int convertValue = (int)value;
                if (convertValue == 1)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
