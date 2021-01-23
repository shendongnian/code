    Dispatcher.Invoke((Action)(() => { }), DispatcherPriority.Render);
    foreach (TreeViewItem tvItem in StaticHelpers.FindVisualChildren<TreeViewItem>(cityTreeView))
    {
        if (tvItem.Header == newlyAddedCity)
        {
            treeViewItem = tvItem;
            break;
        }
    }
