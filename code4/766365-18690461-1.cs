    private static void OnChanged(object source, FileSystemArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Deleted)
        {
            FileItem item = folder.SingleOrDefault(x => x.Name == e.Name);
            if item (item != null)
                folder.Remove(item);
        }
    }
