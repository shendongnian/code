    public static class ListViewEx
    {
        public static int GetSelectedItemsCount(DependencyObject obj)
        {
            return (int)obj.GetValue(SelectedItemsCountProperty);
        }
    
        public static void SetSelectedItemsCount(DependencyObject obj, int value)
        {
            obj.SetValue(SelectedItemsCountProperty, value);
        }
    
        public static readonly DependencyProperty SelectedItemsCountProperty =
            DependencyProperty.RegisterAttached("SelectedItemsCount", typeof(int), typeof(ListViewEx), new PropertyMetadata(0));
    
        public static bool GetAttachListView(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttachListViewProperty);
        }
    
        public static void SetAttachListView(DependencyObject obj, bool value)
        {
            obj.SetValue(AttachListViewProperty, value);
        }
    
        public static readonly DependencyProperty AttachListViewProperty =
            DependencyProperty.RegisterAttached("AttachListView", typeof(bool), typeof(ListViewEx), new PropertyMetadata(false, Callback));
    
        private static void Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                var listView = d as ListView;
                if (listView == null) return;
    
                listView.SelectionChanged += (s, args) =>
                {
                    SetSelectedItemsCount(listView, listView.SelectedItems.Count);
                };
            }
        }
