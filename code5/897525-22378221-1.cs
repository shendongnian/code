     public class conv : IValueConverter
    {
        private string track = null;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (track == null)
                track = value.ToString();
           return parameter.ToString().Equals("true") ? track: track.Substring(0,2);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
