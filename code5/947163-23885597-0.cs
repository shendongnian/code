    public class MyConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members
        public object Convert( object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            return ( (int)values[ 0 ] == (int)values[ 1 ] );
        }
        public object[] ConvertBack( object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture )
        {
            throw new NotImplementedException();
        }
        #endregion
    }
