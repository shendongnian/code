    public class SelectedItemsToListConverter<TIn, TOut> : BaseConverter, IValueConverter where TIn : class where TOut : class
    {
        public IEnumerable<TOut> Convert(object value, object parameter, System.Globalization.CultureInfo culture)
        {
            DataGrid dg = parameter as DataGrid;  
            // You might need some conversion logic here
            return dg.SelectedItems.OfType<TIn>();
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
