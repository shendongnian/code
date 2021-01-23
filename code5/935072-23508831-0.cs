    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        var watcher = sender as FileSystemWatcher;
        try
        {
            MessageBox.Show("File changed.");
            watcher.EnableRaisingEvents = false; // Error: The name 'watcher' does not exist in the current context
        }
        finally
        {
            watcher.EnableRaisingEvents = true; //Error: The name 'watcher' does not exist in the current context
        }
    }
