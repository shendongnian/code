    public class SearchFilterConverter : IMultiValueConverter
    {
       public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
       {
          ....
       }
    
       public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
       {
       }
    }
