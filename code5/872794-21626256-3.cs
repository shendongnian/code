    private readonly object _sendLock = new object();
    void watcher_Created(object sender, FileSystemEventArgs e) 
    {
         System.Diagnostics.Debug.WriteLine(e.FullPath);            
         lock(_sendLock) 
         {
             sendResponse(e.FullPath);
         }
    }
