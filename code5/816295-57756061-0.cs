    private void TreeView_OnScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (e.OriginalSource is ScrollViewer sv)
        {
            Debug.WriteLine(sv.ComputedVerticalScrollBarVisibility);
        }
    }
