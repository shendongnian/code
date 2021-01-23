    public class RowIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            IList list = (IList)values[1];
            return list.IndexOf(values[0]).ToString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
                                    object parameter,
                                    System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
