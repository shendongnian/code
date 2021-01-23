    public class LabelOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is double))
                return DependencyProperty.UnsetValue;
            double doubleValue = (double)value;
            return doubleValue + 285;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // No need to implement, since the binding is in one way mode.
            throw new NotImplementedException();
        }
    }
