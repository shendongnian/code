    public class TextToBrush : IValueConverter
    {
        List<Tuple<string, Brush>> textBrush = new List<Tuple<string, Brush>>()
        {
            new Tuple<string, Brush>("sad", new SolidColorBrush(Colors.Blue))
        };
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return new SolidColorBrush(Colors.Transparent);
            else
                foreach (Tuple<string,Brush> item in textBrush)
                    if ((value as string) == item.Item1) return item.Item2 as Brush;
            return new SolidColorBrush(Colors.Transparent);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
