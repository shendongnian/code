    namespace myApp.Converters
    {
       public class BoolToBrush : IValueConverter
       {
        private Brush FalseValue = (Application.Current.Resources["TransparentBrush"] as Brush);
        private Brush TrueValue = (Application.Current.Resources["PhoneAccentBrush"] as Brush);
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return FalseValue;
            else
                return (bool)value ? TrueValue : FalseValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? value.Equals(TrueValue) : false;
        }
     }
