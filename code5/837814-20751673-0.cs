    public class HighlightConverter : IValueConverter
    {
        private int[] _includedNumbers = { 1, 5, 12, 15 };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as int? != null && _includedNumbers.Contains((int)value) ? true : false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
