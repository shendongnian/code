    private void TreeView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        var treeView = (TreeView) sender;
        foreach (TreeViewItem treeViewItem in treeView.Items)
        {
            foreach (ItemsControl ic in treeViewItem.Items)
            {
                Point relativeLocation = ic.TranslatePoint(new Point(0, 0), treeView);
                var wpMaxWidth = treeView.ActualWidth - relativeLocation.X;
                
                WrapPanel itemsWp = GetVisualChild<WrapPanel>(ic);
                itemsWp.MaxWidth = wpMaxWidth;
            }
        }
    }
    private static T GetVisualChild<T>(DependencyObject parent) where T : Visual
    {
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < numVisuals; i++)
        {
            Visual v = (Visual) VisualTreeHelper.GetChild(parent, i);
            var child = v as T;
            return child ?? GetVisualChild<T>(v);
        }
        return null;
    }
