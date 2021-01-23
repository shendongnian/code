    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value == null)
            return System.Windows.Media.Color.White;
        if ((int)value < 0)
            return System.Windows.Media.Color.Red;
        return System.Windows.Media.Color.White;
    }
