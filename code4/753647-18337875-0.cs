    public class MyConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            // First cast the value to an 'int'.
            Int32 theInputtedValue = (Int32)value;
            // Then return the newly formatted string.
            return String.Format("{0}% Completed", theInputtedValue);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
