    public class ItemExistInRangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
                              object parameter, CultureInfo culture)
        {
            bool itemsExistInRange = false;
            if (values.Length == 3)
            {
                int outputValue = int.MinValue;
                if (Int32.TryParse(values[0].ToString(), out outputValue))
                {
                    int minValue = (int)values[1];
                    int maxValue = (int)values[2];
                    itemsExistInRange = minValue <= outputValue
                                         && outputValue <= maxValue;
                }
            }
            return itemsExistInRange;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes,
                                    object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
