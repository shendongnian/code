    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((int)value == (int)parameter)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
