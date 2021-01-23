    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var cell = value as Order;
            if (cell != null && cell.Size > 80)
                return new SolidColorBrush(Colors.Red);
            else return new SolidColorBrush(Colors.Yellow);
        }
