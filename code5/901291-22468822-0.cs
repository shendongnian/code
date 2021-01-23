    FileSystemWatcher watcher;
    public void StartWatch()
    {
        // Create a new FileSystemWatcher and set its properties.
        watcher = new FileSystemWatcher();
        watcher.Path = "Path to directory"; // Put the path to your directory here
        // Watch for changes in LastWrite
        watcher.NotifyFilter = NotifyFilters.LastWrite;
        // Add event handlers.
        watcher.Created += new FileSystemEventHandler(OnCreated);
        // Begin watching.
        watcher.EnableRaisingEvents = true;
    }
    // Define the event handlers. 
    private static void OnCreated(object source, FileSystemEventArgs e)
    {
        MessageBox.Show("A File has been created");
    }
