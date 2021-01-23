    public class InitialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value as string;
            string i = string.Empty;
            if (s != null)
            {
                string[] split = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string piece in split)
                {
                    i += piece[0];
                }
            }
            return i;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
