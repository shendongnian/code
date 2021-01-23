    private void SendTo(List<string> FileCollection)
    {
        // Clear your previous FileList.
        FileList.Clear();
        foreach (string file in Filecollection)
        {
            FileList.Add(file); 
        }
        // Rest of the code. 
    }
    List<string> FileList { get; set; }
    private void WatchFilesBeforeTransfer(string DestinationFolder)
    {
        // Same code as before, but delete FileToWatch.
    }
    private void FileRenamed(Object source, RenamedEventArgs e)
    {
        foreach (string file in FileList)
        {
            if (e.Name == file)
            {
                // Do stuff.
            }
        }
    }
    private void FileCreated(Object source, FileSystemEventArgs e)
    {
        foreach (string file in FileList)
        {
            if (e.Name == file)
            {
                // Do stuff.
            }
        }
    }
