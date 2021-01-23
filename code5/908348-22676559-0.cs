    public class BooleanToVisibilityConverter : IValueConverter
    {
       public object Convert (object value, ...)
       {
           if ((bool)value)
              return Visibility.Visible;
           else
              return Visibility.Collapsed;
       }
    
       public object ConvertBack(object value, ...)
       {
          return Binding.DoNothing;
       }
    }
