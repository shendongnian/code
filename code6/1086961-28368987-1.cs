    namespace ExceptionLogViewer
    {
        public class DateToCustomDate : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is DateTime)
                {
                    var date = (DateTime)value;
                    if (date == DateTime.Today)
                    {
                        return string.Format("{0:d} {0:t}", date);
                    }
                    else
                    {
                        return string.Format("{0:d}", date);
                    }
                }
                else
                {
                    return value;
                }
            }
        
            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
