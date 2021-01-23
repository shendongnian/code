    public class ExpanderToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // to prevent NullRef
            if (value == null || parameter == null)
                return false;
            var sValue = value.ToString();
            var sparam = parameter.ToString();
            return (sValue == sparam);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToBoolean(value)) return parameter;
            return null;
        }
    }
