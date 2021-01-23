    public class FilterTextValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            string text = value.ToString(); // TEXT for textBox can be accessed here.
            return new List<string>(); // Return filtered list from here.
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                                  System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
