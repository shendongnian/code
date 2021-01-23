    public class HighlightConverter : IValueConverter
    {
        private int[] _highlightedNumbers = { 1, 5, 12, 15 };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value as int? == null)
                return false;
            // get the highlighted numbers, either hard-coded locally, or passed in as the ConverterParameter
            int[] highlightedNumbers;
            var numbersCsv = parameter as string;
            if (!string.IsNullOrEmpty(numbersCsv))
                highlightedNumbers = numbersCsv.Split(',').Select(item => int.Parse(item.Trim())).ToArray();
            else
                highlightedNumbers = _highlightedNumbers;
            return highlightedNumbers.Contains((int)value) ? true : false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
