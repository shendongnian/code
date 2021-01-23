     public class StringToUpperStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    		{
    		    var valueString = value.ToString();
    		    if (!string.IsNullOrEmpty(valueString))
    		    {
    		        return valueString.ToUpper();
    		    }
    
    		    return string.Empty;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
