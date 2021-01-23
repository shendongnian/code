    public class TextConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var trueText = (string)values[0];
            var falseText = (string)values[1];
            var condition = (bool)values[2];
            return condition ? trueText : falseText;
        }
        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
