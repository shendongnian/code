    public object Convert(
        object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null || values.Length != 2 ||
            ReferenceEquals(values[0], DependencyProperty.UnsetValue) ||
            ReferenceEquals(values[1], DependencyProperty.UnsetValue))
        {
            return 240d;
        }
        var maxFrame = System.Convert.ToInt32(values[0]); // or ToDouble
        var currentZoom = System.Convert.ToInt32(values[1]); // or ToDouble
        return (double)(currentZoom * maxFrame);
    }
