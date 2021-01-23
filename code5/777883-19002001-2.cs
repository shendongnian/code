    namespace MVVMTests
    {
        [ValueConversion(typeof(Boolean), typeof(SolidColorBrush))]
        public class RectangleControlFillConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                SolidColorBrush brush;
                bool b = (bool)value;
                if (b)
                    brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5C8FFF"));
                else
                    brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#73E34D"));
                return brush;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
