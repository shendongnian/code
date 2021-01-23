    public class typeconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = value.ToString();
            if (text != null)
            {
                if (text == "1")
                {
                   return "/Assets/call.png";                    
                }
                if (text == "2")
                {
                   return "/Assets/wtp.png";                   
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
