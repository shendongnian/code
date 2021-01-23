    public class AmountToCellStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueAsDecimal = (int)value;
            if (valueAsDecimal > 0)
            {
                return Application.Current.FindResource("WinCellStyle") as Style;
            }
            return Application.Current.FindResource("LossCellStyle") as Style;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
