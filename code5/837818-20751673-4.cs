    public class HighlightConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var includedNumbers = values[0] as int[];
            if (includedNumbers == null || values[1] as int? == null)
                return false;
            return includedNumbers.Contains((int)values[1]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
