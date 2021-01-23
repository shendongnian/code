    public class DateToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = value as DateTime?;
            if (!date.HasValue)
                return new SolidColorBrush(Colors.Transparent);
            else if (!date.Value > DateTime.Today.AddDays(-1))
                return new SolidColorBrush(Colors.Blue);
            // etc
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
