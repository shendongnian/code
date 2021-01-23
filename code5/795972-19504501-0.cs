    public class RoundNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.IsNumber())
                return DependencyProperty.UnsetValue;
            return Math.Round((float)value, 2).ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            var svalue = value.ToString();
            if (svalue.EndsWith(".")) // Prevents problems when using this with UpdateTrigger.PropertyChanged and user enters 1.
                return DependencyProperty.UnsetValue;
            float number;
            if (!float.TryParse(svalue, out number))
                return DependencyProperty.UnsetValue;
            return number;
        }
    }
