    // let the key be Name, and value be Path.
    public static Dictionary<string, string> folder = new Dictionary<string, string>();
    
    private static void OnChanged(object source, FileSystemArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Deleted)
        {
            folder.Remove(e.Name);
        }
    }
