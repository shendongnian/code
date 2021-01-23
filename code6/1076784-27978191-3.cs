    public class ListBoxWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2)
            {
                var actualWidth = System.Convert.ToDouble(values[0]);
                var numOfItems = System.Convert.ToInt32(values[1]);
                return (actualWidth / numOfItems) - 10;
            }
            return Binding.DoNothing;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
