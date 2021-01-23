    private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
    {
       TreeViewItem tvi = (TreeViewItem)e.OriginalSource;
       if (tvi != null)
          tvi.IsExpanded = !tvi.IsExpanded;
    }
