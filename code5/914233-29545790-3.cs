    public class MyVirtualizingStackPanel : VirtualizingStackPanel
    {
        protected override void OnCleanUpVirtualizedItem(CleanUpVirtualizedItemEventArgs e)
        {
            var item = e.UIElement as ListBoxItem;
            if (item != null && item.IsSelected)
            {
                e.Cancel = true;
                e.Handled = true;
                return;
            }
            var item2 = e.UIElement as TreeViewItem;
            if (item2 != null && item2.IsSelected)
            {
                e.Cancel = true;
                e.Handled = true;
                return;
            }
            base.OnCleanUpVirtualizedItem(e);
        }
    }
