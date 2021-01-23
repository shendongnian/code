     public class ValueConverter : IValueConverter
        {
            public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null || !(value is decimal))
                    return new SolidColorBrush(ForegroundBrush);
    
                var dValue = System.Convert.ToDecimal(value);
                if (dValue < 0)
                    return new SolidColorBrush(ForegroundBrush);
                else
                    return new SolidColorBrush(ForegroundBrush);
            }
    
            public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
    
        }    
   
