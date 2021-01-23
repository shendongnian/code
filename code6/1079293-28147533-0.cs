    public class ObservableStringCollectionToMultiLineStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<string> logEntries = values[0] as ObservableCollection<string>;
            StringBuilder sb = new StringBuilder();
            if (logEntries != null && logEntries.Count > 0)
            {
                foreach (string msg in logEntries)
                {
                    sb.AppendLine(msg);
                }
                return sb.ToString();
            }
            else
                return String.Empty;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
