     public class WordSplitConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string input = value.ToString();
                // you can parameterize the split position via the ConverterParameter
                string left = input.Substring(0,2);
                string right= input.Substring(2,input.Length-3);
                return string.Format("{0}X{1}",left ,right);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
