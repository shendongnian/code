    public class TypeToImageConverter : IValueConverter
    {
           public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
               throw ...
            
            var str = value.ToString();
            if (str == "income")
               return new BitmapImage(...);
            if (str = "expenses")
               return new BitmapImage(...);
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
