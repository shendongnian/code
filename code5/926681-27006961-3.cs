    public class ConfirmPasskey : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parm, System.Globalization.CultureInfo culture)
        {
            if ((values[0] as PasswordBox).Password.Equals((values[1] as PasswordBox).Password))
                return null;
            return "Passcodes do not match.";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parm, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
