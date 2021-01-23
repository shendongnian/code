    public object Convert(
         object[] values, Type targetType, object parameter,CultureInfo culture)
    {
        object result = null;
        if (values.Length == 2 && values[0] is string && values[1] is bool)
        {
            var imagePath = (string)values[0];
            var isPublic = (bool)values[1];
            ...
        }
        return result;
    }
