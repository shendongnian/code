    public class NumberConverter : IValueConverter
    {
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //do you conversion here - "value" is the parameter you need to convert and return
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //you can optionally implement the conversion back (from scientific value to integer)
            throw new NotImplementedException();
        }
    }
