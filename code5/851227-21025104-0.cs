    public class StringToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            DateTime d;
            try
            {
                d = System.Convert.ToDateTime(value);
                return d;
                // The WPF code that uses this converter will then use the stringformat 
                // attribute in binding to display just HH:mm part of the date as required.
            }
            catch (Exception)
            {
                // If we're unable to convert the value, then best send the value as is to the UI.
                return value;
            }
            
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Insert your implementation here...
            return value;
        }
    }
