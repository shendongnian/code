    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate First { get; set; }
        public DataTemplate Default { get; set; }
        public DataTemplate Last { get; set; }
    
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var listViewItem = container as ListViewItem;
            var listView = GetParentByType<ListView>(listViewItem); 
    
            var index = (listView.ItemsSource as IList).IndexOf(item);
            var totalCount = (listView.ItemsSource as IList).Count;
    
            if (index == 0)
                return First;
            else if (index == totalCount - 1)
                return Last;
            else
                return Default;
        }
    
        private T GetParentByType<T>(DependencyObject element) where T : FrameworkElement
        {
            T result = null;
            DependencyObject parent = VisualTreeHelper.GetParent(element);
    
            while (parent != null)
            {
                result = parent as T;
    
                if (result != null)
                {
                    return result;
                }
    
                parent = VisualTreeHelper.GetParent(parent);
            }
    
            return null;
        }
    }
