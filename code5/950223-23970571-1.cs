     public class DateTimeConverter:IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                DateTime dateValue = (DateTime)value;
    
                return dateValue.ToString("yyyy/MM/dd/");
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
