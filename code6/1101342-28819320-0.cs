    ...
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null || values.Length != 2 || values.Any(v => DependencyProperty.UnsetValue.Equals(v)))
            return 240d;
        return values.Cast<double>().Aggregate((v1, v2) => v1 * v2);
    }
    ...
