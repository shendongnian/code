    foreach (string subdir in dirs)
    {
        TreeViewItem subItem = new TreeViewItem() { Header = subdir, IsExpanded= true };
        startButton.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
        (ThreadStart)delegate()
        {
            item.Items.Add(subItem);
        });
        InitTree(subItem, subdir);
    }
