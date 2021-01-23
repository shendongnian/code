    public class DateTimeToStringConverter : IValueConverter
    {
        private DateTime currentDisplayDate;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            currentDisplayDate = (DateTime)value;
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           bool flag;
                DateTime output;
                flag = DateTime.TryParseExact(currentDisplayDate.Day + " " + value.ToString().Trim() + " " + currentDisplayDate.Year, "d MMMM yyyy",
                                                CultureInfo.InvariantCulture,DateTimeStyles.None,out output);
            /* To handle month last day difference */
               if(!flag)
                flag = DateTime.TryParseExact(1 + " " + value.ToString().Trim() + " " + currentDisplayDate.Year, "d MMMM yyyy",
                                                CultureInfo.InvariantCulture, DateTimeStyles.None, out output);
           return flag ? output : currentDisplayDate;  
         
        }
    }
