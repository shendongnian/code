    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((MyStatus)value) == MyStatus.Opened;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((bool)value) ? MyStatus.Opened : MyStatus.Closed;
    }
