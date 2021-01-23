    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        return string.Join(",",
            (((IEnumerable<object>)value).Select(x => x.GetType()
                                         .GetProperty(parameter.ToString()).GetValue(x))));
    }
