    public class ProductConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value as List<Product> != null) {
                return (value as List<Product>).GroupBy(a => new { a.ProductType });
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
