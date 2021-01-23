    public class SearchFilterConverter : IMultiValueConverter
    {
     public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
     {
        return new Tuple<String, bool>((String)values[0], (bool)values[1]);;
     }
     public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
