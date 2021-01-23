    public class CheckboxIsCheckedValueConverter : IValueConverter {
        public object OriginalValue;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                OriginalValue = value;
                return true;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((bool)value == true) {
                return OriginalValue;
            } else {
                return null;
            }
        }
    }
