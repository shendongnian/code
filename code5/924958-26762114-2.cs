    public class CommandGroupToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) 
        {
            return (System.Convert.ToInt32(value) == System.Convert.ToInt32(parameter)) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
