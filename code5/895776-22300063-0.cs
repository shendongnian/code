    public class IsLastItemInContainerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
                              CultureInfo culture)
        {
            DependencyObject item = (DependencyObject)values[0];
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(item);
            if (ic != null)
            {
                return ic.ItemContainerGenerator.IndexFromContainer(item)
                          == ic.Items.Count - 1;
            }
            else
                return false;
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
                                    object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
