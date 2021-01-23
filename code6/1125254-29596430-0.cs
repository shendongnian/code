    public class MyUrlConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if(value == null)
                {
                    return null;
                }
                var urlString = value as string;
    
                //now do whatever you want to do with the string
                //then return it
                return urlString;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
