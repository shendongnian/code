    public class IDictionarySelector : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values != null && values.Length == 2)
            {
                IDictionary idictionary = values[0] as IDictionary;
                int? key = values[1] as int?;
                if ((idictionary != null) && (key != null) && (idictionary.Contains(key)))
                {
                    return idictionary[key].ToString();
                }
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
