    public class InitialsConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str != null)
            {
                string s = "";
                MatchCollection matches = Regex.Matches(str, @"(\b\w)");
                foreach (Match m in matches)
                    s += m.Value;
                return s;
            }
            else
            {
                return null;
            }
        }
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
