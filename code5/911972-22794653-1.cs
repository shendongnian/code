    namespace WpfApplication1
    {
        public class IdToPriceConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var id = values[0] is int ? (int) values[0] : -1;
                var prices = values[1] as Dictionary<int, decimal>;
    
                if (-1 != id)
                {
                    if (null != prices)
                    {
                        return prices[id].ToString(CultureInfo.InvariantCulture);
                    }
                }
                return String.Empty;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
