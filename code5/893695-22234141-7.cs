    public class ResourceToValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            return ((ResourceDictionary)values[1])[values[0]];
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
                                    object parameter, 
                                    System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
