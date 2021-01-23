    private void nodeTree_Drop(object sender, DragEventArgs e)
        {
            //find the ancestor using the below method, this gets the TreeViewItem Object
            TreeViewItem treeViewItem = FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);
            if (treeViewItem != null)
            {
               treeViewItem.Background = Brushes.White;
               //Convert the header into the origional object
               var droppedNode = (TreeNodeVM)treeViewItem.Header;
            }
        }
    private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            // Search the VisualTree for specified type
            while (current != null)
            {
                if (current is T)
                {
                    return (T) current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }
