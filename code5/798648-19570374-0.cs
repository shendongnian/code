    public object Convert( object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture )
    {
        double result = 0;
        try
        {
            result = (double)((int)value);
        }
        catch (Exception) { }
        return result;
    }
    public object ConvertBack( object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture )
    {
        return (int) ((double)value);
    }
}
