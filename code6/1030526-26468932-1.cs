     public class CheckConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return (bool)((bool)values[0] || (bool)values[1]);
    
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                object[] splitValues = { value, false };
                return splitValues;
            }
        }
