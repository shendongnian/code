       public class IsEqual : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetTypes, object parameter, CultureInfo culture)
        {
            if (values[0] == "")
                return string.Format("blank");
            // returns yes if equal
            else if (string.Equals(values[0], values[1]))
                return string.Format("yes");
            //returns no if not equal
            else
                return String.Format("no");
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
