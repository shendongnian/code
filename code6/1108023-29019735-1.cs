    public class ListBoxItemIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ListBoxItem item = (ListBoxItem)value;
            var listBox = (ListBox)ItemsControl.ItemsControlFromItemContainer(item);
            return listBox.ItemContainerGenerator.IndexFromContainer(item);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
