    private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem trvItem = (TreeViewItem)tree.SelectedItem;
    
            if (trvItem != null)
            {
                String path = (String)trvItem.Tag;
                MessageBox.Show(path);
            }
        }
