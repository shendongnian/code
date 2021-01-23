    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string name1 = values.ElementAtOrDefault(0) as string, 
                name2 = values.ElementAtOrDefault(1) as string;
            return name1 ?? name2;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
