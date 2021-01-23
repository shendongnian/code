    private static void OnChanged(object source, FileSystemArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Deleted)
        {
            FileItem item = folder.Where(x => x.Name == e.Name).FirstOrDefault();
            if item (item != null)
                folder.Remove(item);
        }
    }
