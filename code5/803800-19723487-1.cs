    [ValueConversion(typeof (bool?), typeof (Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public const string Invert = "Not";
        private const string TypeIsNotAllowed = "The type '{0}' is not allowed.";
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = value as bool?;
            if (boolValue == null)
                throw new NotSupportedException(String.Format(TypeIsNotAllowed, value.GetType().Name));
            return ((boolValue.Value && !IsInverted(parameter)) || (!boolValue.Value && IsInverted(parameter))) 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibilityValue = value as Visibility?;
            if (visibilityValue == null)
                throw new NotSupportedException(String.Format(TypeIsNotAllowed, value.GetType().Name));
            return visibilityValue == Visibility.Visible && !IsInverted(parameter);
        }
        #endregion
        private static bool IsInverted(object param)
        {
            var strParam = param as string;
            if (param == null || string.IsNullOrEmpty(strParam))
                return false;
            return strParam.Equals(Invert, StringComparison.InvariantCultureIgnoreCase);
        }
    }
