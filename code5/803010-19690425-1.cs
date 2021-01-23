        private void TreeViewItem_OnExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = sender as TreeViewItem;
            Debug.Assert(tvi != null);
            if (tvi.HasItems) { ExpandChildren(tvi); }
        }
        private void ExpandChildren(TreeViewItem tvi)
        {
            foreach (var item in tvi.Items)
            {
                if (item is TreeViewItem) { ExpandChildren(item as TreeViewItem); }
            }
            tvi.IsExpanded = true;
        }
