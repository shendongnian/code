     public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "!!!";
            return   value.ToString().BarkYourName();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public static class StringExt
    {
        public static string BarkYourName(this string str)
        {
            return str + "!!!";
        }
    }
