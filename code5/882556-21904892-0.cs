    public class MyFormatter : IValueConverter
    {
      public object Convert(object value, Type tagetType, object parameter, CultureInfo culture)
      {
         return string.Format("{0:hh:mm}", value)+" Uhr";
      }
    ...
    //Just throw NotImplemented for ConvertBack
    }
