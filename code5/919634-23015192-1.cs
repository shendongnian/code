    namespace WpfApplication4 {
        public class WidthConverter : IValueConverter {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                Console.WriteLine(value.GetType());
                var w = (double)value;
                return w - 350;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException();
            }
        }
    }
