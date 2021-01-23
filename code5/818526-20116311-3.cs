    public class BoolToImageSource : IValueConverter
    {
      public System.Windows.Media.ImageSource FalseValue;
      public System.Windows.Media.ImageSource TrueValue;
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         TrueValue = new BitmapImage(new Uri("/Resources/tick.png", UriKind.RelativeOrAbsolute));
         FalseValue = new BitmapImage(new Uri("/Resources/blank.png", UriKind.RelativeOrAbsolute));
         
         if (value == null)
            return FalseValue;
         else
            return (bool)value ? TrueValue : FalseValue;
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return value != null ? value.Equals(TrueValue) : false;
      }
    }
