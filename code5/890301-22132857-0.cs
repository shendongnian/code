    public class IntToThicknessConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness((double)values[0], (double)values[1], (double)values[2], (double)values[3]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Thickness t = (Thickness)value;
            return new object[]{t.Left,t.Top,t.Right,t.Bottom};
        }
    }
