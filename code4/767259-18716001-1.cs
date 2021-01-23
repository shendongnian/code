    public class AdditiveInverseDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(double) && targetType != typeof(double)) return false;
            return -(double)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(double) && targetType != typeof(double)) return false;
            return -(double)value;
        }
    }
