    using Windows.UI.Xaml.Data;
    public class FromobjectToToobjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Converting code here
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Convert back here
            throw new NotImplementedException();
        }
    }
