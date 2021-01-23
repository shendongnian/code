    public object Convert(object value, Type targetType, object parameter,
                          System.Globalization.CultureInfo culture)
    {
        if (value is DateTime)
        {
            DateTime test = (DateTime) value;
            string date = test.ToString("d/M/yyyy");
            return date;
        }
        return string.Empty;
    }
