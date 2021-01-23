    public class AppTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (byte)value;
            if (b == 1) return "Normal";
            if (b == 2) return "Expedited";
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cb = (ComboBoxItem) value;
            var strValue = (string)cb.Content;
            byte result = 0;
            if (strValue.Equals("Normal", StringComparison.Ordinal))
            {
                result = 1;
            }
            else if (strValue.Equals("Expedited", StringComparison.OrdinalIgnoreCase))
            {
                result = 2;
            }
            return result;
        }
    }
