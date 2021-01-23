    public class ListBoxItemIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dependencyObject = value as DependencyObject;
            var item = FindFirstParentOfType<ListBoxItem>(dependencyObject);
            if (item == null)
                return null;
            var listBox = (ListBox) ItemsControl.ItemsControlFromItemContainer(item);
            if (listBox == null)
                return null;
            return listBox.ItemContainerGenerator.IndexFromContainer(item);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private static T FindFirstParentOfType<T>(DependencyObject dependencyObject) 
            where T : DependencyObject
        {
            while (true)
            {
                if (dependencyObject == null)
                    return null;
                var parent = VisualTreeHelper.GetParent(dependencyObject);
                var findFirstParentOfType = (parent as T);
                if (findFirstParentOfType != null)
                    return findFirstParentOfType;
                dependencyObject = parent;
            }
        }
    }
    
