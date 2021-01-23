    [ValueConversion(typeof(string), typeof(FrameworkElement))]
    public class XamlStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FrameworkElement result = null;
            string xaml = value as string;
            if (!string.IsNullOrEmpty(xaml))
            {
                try
                {
                    result = XamlReader.Parse(xaml) as FrameworkElement;
                }
                catch (Exception ex)
                {
                    //add logging logic here.
                }
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
