    public class DoubleMultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double)) return null;
            double multiplier = 1;
            double.TryParse(parameter as string, out multiplier);
            return ((double)value) * multiplier;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Not needed
            return null;
        }
    }
