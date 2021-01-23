    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                if (!string.IsNullOrEmpty((string)value))
                    return Visibility.Visible;
            }
            else if (value != null)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
