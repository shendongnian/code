    public class MultiDateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(values.First() is DateTime))
                return DependencyProperty.UnsetValue;
            return string.Format("{0:N1} seconds ago", DateTime.Now.Subtract((DateTime)values.First()).TotalSeconds);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
