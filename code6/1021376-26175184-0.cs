    private TabItem GetTargetTabItem(object originalSource)
    {
        var current = originalSource as DependencyObject;            
        
        while (current != null)
        {
            var tabItem = current as TabItem;
            if (tabItem != null)
            {
                return tabItem;
            }
            current = VisualTreeHelper.GetParent(current);
        }
        return null;
    }
    private void TabItem_Drop(object sender, DragEventArgs e)
    {
        var tabItemTarget = GetTargetTabItem(e.OriginalSource);
        if (tabItemTarget != null)
        {
            var tabItemSource = (TabItem)e.Data.GetData(typeof(TabItem));
            if (tabItemTarget != tabItemSource)
            {
                // the rest of your code
            }
        }
    }
