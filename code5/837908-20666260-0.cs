    public class ByteToHexadecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || targetType != typeof(string)) return DependencyProperty.UnsetValue;
            byte byteValue = 0;
            if (!byte.TryParse(value.ToString(), out byteValue)) return DependencyProperty.UnsetValue;
            return byteValue.ToString("x2");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || targetType != typeof(byte)) return DependencyProperty.UnsetValue;
            string stringValue = value.ToString();
            byte returnValue = 0;
            try { returnValue = System.Convert.ToByte(stringValue, 16); }
            catch { return DependencyProperty.UnsetValue; }
            return returnValue;
        }
    }
