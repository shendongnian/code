     public class WordSplittConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string input = value.ToString();
                string[] strings = input.Split('.');
                return string.Format("{0}-WHATEVER-{1}", strings[0], strings[1]);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
