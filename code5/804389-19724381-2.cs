    public class DoubleToLargerDoubleConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(double)) return false;
            double amountToEnlargeBy = 0;
            if (parameter == null || double.TryParse(parameter.ToString(), out amountToEnlargeBy)) return false;
            double doubleValue = (double)value;
            return doubleValue + amountToEnlargeBy;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
