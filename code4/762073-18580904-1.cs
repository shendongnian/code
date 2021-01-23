    private TreeViewItem _selectedItem = null;
    void treeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
            // Go ahead with selection change...
            Dispatcher.BeginInvoke(new Action(() =>
            {
                _selectedItem.IsSelected = true;
            }),
            DispatcherPriority.ContextIdle);
            // Update _selectedItem for comparison the next time this method fires.
            _selectedItem = tvi;
        }
    }
