    private void TreeView_MouseDoubleClick(object sender, RoutedEventArgs e)
    {
        TreeViewItem tviSender = sender as TreeViewItem;
        if (tviSender == null || !tviSender.IsSelected)
        {
            return;
        }
        MessageBox.Show(trvMenu.SelectedItem.Title);
    }
