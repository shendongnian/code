    public class MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var sb = new StringBuilder();
            sb.AppendLine(values[0].ToString());
            foreach (var kvp in (Dictionary<string, string>) values[1])
                sb.AppendLine(kvp.Key + "-" + kvp.Value);
            return sb.ToString();
        }
        //...
    }
