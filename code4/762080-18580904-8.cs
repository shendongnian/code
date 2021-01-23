    private TreeViewItem _selectedItem = null;
    void treeViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        TreeViewItem tvi = GetFirstAncestorOfType<TreeViewItem>(e.OriginalSource as DependencyObject);
        if (_selectedItem != null &&
            tvi != _selectedItem &&
            MessageBoxResult.Yes != DoYouAgreeToMoveToAnotherItem())
        {
            e.Handled = true;
        }
        else
        {
            // Update _selectedItem for comparison the next time this method fires.
            _selectedItem = tvi;
            if(_selectedItem != null)
                _selectedItem.IsSelected = true;
        }
    }
