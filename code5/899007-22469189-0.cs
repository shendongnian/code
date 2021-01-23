    foreach (string subdir in dirs)
    {
        startButton.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
        (ThreadStart)delegate()
        {
            TreeViewItem subItem = new TreeViewItem() { Header = subdir, IsExpanded= true };
            item.Items.Add(subItem);
            InitTree(subItem, subdir);
        });
    }
