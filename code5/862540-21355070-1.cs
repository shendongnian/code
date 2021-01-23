    public class WindDirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
                              object parameter, CultureInfo culture)
        {
            return MapValue(value.ToString());
        }
    
        public object ConvertBack(object value, Type targetType, 
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
