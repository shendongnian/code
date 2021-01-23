    public class StringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = values[0].ToString();
            int index = (int)values[1];
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            int lastIndex = text.IndexOf(' ', index);
            int firstIndex = new String(text.Reverse().ToArray()).IndexOf(' ', index);
            return text.Substring(firstIndex, lastIndex - firstIndex);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
