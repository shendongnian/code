    public class EmptyDateCoverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is DateTime)
            {
                if((DateTime)value == DateTime.MinValue)
                {
                     return "";
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //We don't need convert back
            throw new NotImplementedException();
        }
    }
