    public class UserTypeVisibilityConverter : IValueConverter
    {
        // I can set this property to define which enum value makes the controls visible
        // all other values make them invisible
        public UserType VisibleUserType { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is UserType))
            {
                return value;
            }
            var userType = (UserType) value;
            return userType == VisibleUserType ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
