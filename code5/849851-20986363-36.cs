    public class SelectedItemIsCorrectToBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var boolValues = values.OfType<bool>().ToList();
            var isCorrectValue = boolValues[0];
            var isSelected = boolValues[1];
            if (isSelected)
            {
                return isCorrectValue;
            }
            return DependencyProperty.UnsetValue;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
