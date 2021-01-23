    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        object result = null;
        switch ((EstateCode)value)
        {
            case EstateCode.EstateCode1:
                result = new BitmapImage(new Uri("pack://application:,,,/Images/Estate1.jpg"));
                break;
            case EstateCode.EstateCode2:
                result = new BitmapImage(new Uri("pack://application:,,,/Images/Estate2.jpg"));
                break;
        }
        return result;
    }
