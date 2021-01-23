       public class StackpanelChildrenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           var stackpanel = value as stackpanel;
 		   return stackpanel.Children.OfType<UserControl>().Count() * 300;
        }
    }
