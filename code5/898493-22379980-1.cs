     public class conv : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ObservableCollection<string> lista = (ObservableCollection<string>)values[1];
            return String.Concat(lista.IndexOf(values[0].ToString()), " ", values[0].ToString());
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
