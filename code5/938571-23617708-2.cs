    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is bool && targetType == typeof(Visibility))
        {
            bool val = (bool)value;
            if (val)
                return Visibility.Visible;
            else
                if (parameter != null && parameter is Visibility)
                    return parameter;
                else
                    return Visibility.Collapsed;
        }
        
        // ...
    }
