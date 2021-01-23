	public class ProductTypeConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			if(values[0] != null && values[0] != DependencyProperty.UnsetValue &&
				values[1] != null && values[1] != DependencyProperty.UnsetValue) {
				string f= (values[1] as List<ProductType>)
                          .Where(a => a.ProductTypeID.Equals(values[0]))
                          .First().Description;
				return f;
			}
			return false;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			return null;
		}
	}
