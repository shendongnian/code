    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value != null && value is DateTime && (DateTime)value < new DateTime(2, 1, 1))
        {
            return "NA";
        }
        else
            return value;
    }
