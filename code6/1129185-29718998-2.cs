    class Converter_Position : IMultiValueConverter
    {
        public object Convert(object[] values, Type t, object parameter, CultureInfo culture)
        {
            RaPoint Position = values[1] as RaPoint;
            return Position.ToString();
        }
    
        public object ConvertBack(object[] values, Type t, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
