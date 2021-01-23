    public class FilterTextValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            var trackedColors = values[0] as List<Colors>;
            if (trackedColors != null && !String.IsNullOrEmpty(values[1].ToString()))
                return (trackedColors).Where(item => 
                       item.ColorName.Contains(values[1].ToString())).ToList();
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
                                    object parameter,
                                    System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
