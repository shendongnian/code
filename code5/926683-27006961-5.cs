    public class ConfirmPasskey : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parm, System.Globalization.CultureInfo culture)
        {
            bool match = (values[0] as PasswordBox).Password.Equals((values[1] as PasswordBox).Password);
    
            if (targetType.Name.Equals("Nullable`1"))
                return match;
            return (match) ? null : "Passcodes do not match.";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parm, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
