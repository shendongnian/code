    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = true;
            Module module = values[0] as Module;
            User user = values[1] as User;
            bool userHasAccess = false;
            UserModule userModule = user.UserModules.SingleOrDefault(um => um.Module_ID == module.Module_ID);
            if (userModule != null)
            {
                userHasAccess = userModule.User_Module_Access == 1;
            }
            
            return result = ! module.ModuleDisabled && module.ModuleLicenseDate > DateTime.Now && userHasAccess;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
