    public class ItemCountToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                IEnumerable<Person> collection = (IEnumerable<Person>)values[0];
                int count = collection.Count(item => item.CustName ==
                                                      values[1].ToString());
                return (count > 1) ? Brushes.Green : Brushes.Transparent;
            }
            return Brushes.Transparent;
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
                                    object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
