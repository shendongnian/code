    public class ItemExistInRangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
                              object parameter, CultureInfo culture)
        {
            bool itemsExistInRange = false;
            if (values.Length == 2)
            {
                int outputValue = int.MinValue;
                int[] rangeNumbers = (int[])values[1];
                if (Int32.TryParse(values[0].ToString(), out outputValue))
                {
                    itemsExistInRange = rangeNumbers.Contains(outputValue);
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
