    public class RatingToStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                // Validate parameters
                /*if (!(value is double))
                {
                    throw new NotSupportedException("Unsupported value type in RatingToStringConverter.");
                }
                */
                // Convert number to string
                //int  idoubleValue = Math.Ceiling ((double)value);
                int  doubleValue = System.Convert.ToInt32(value);
                //int  doubleValue = (int)value;
                string a = (doubleValue / 60).ToString();
                string b = (doubleValue % 60).ToString();
    
                return a + ":" + b;
                
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
