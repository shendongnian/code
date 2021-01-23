    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var str = (string)value;
        var r = Byte.Parse(str.Substring(0, 2), NumberStyles.HexNumber);
        var g = Byte.Parse(str.Substring(2, 2), NumberStyles.HexNumber);
        var b = Byte.Parse(str.Substring(4, 2), NumberStyles.HexNumber);
        return new SolidColorBrush(Color.FromRgb(r, g, b));
    }
