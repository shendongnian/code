    public void Watcher()
    {
        //Create a new FileSystemWatcher.
        FileSystemWatcher watcher = new FileSystemWatcher();
        //Set the filter to only catch TXT files.
        watcher.Filter = "*.txt";
        
        //Subscribe to the Created event.
        //Created Occurs when a file or directory in the specified Path is created.
        //You can change this based on what you are trying to do.
        watcher.Created += new FileSystemEventHandler(YOUR_EVENT_HANDLER);
        //Set the path to you want to monitor
        watcher.Path = @"C:\PATH\";
        //Enable the FileSystemWatcher events.
        watcher.EnableRaisingEvents = true;
    }
