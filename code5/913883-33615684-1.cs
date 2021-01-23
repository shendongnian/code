    public class StringResourceConverter : IMvxValueConverter
    {
        private static ResourceManager manager = new ResourceManager(typeof(AppResources));
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ignore value. We are using parameter only.
            return manager.GetString((string)parameter);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
