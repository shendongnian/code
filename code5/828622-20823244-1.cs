    public void Scan()
    {
        // ...
        // enumerate all directories under one root folder (mof.Folder)
        var directories = Directory.EnumerateDirectories(mof.Folder, "*", SearchOption.AllDirectories);
        // use parallel foreach from TPL to process folders
        Parallel.ForEach(directories, ProcessFolder);
        // ...
    }
    
    private void ProcessFolder(string folder)
    {
        if (!Directory.Exists(folder))
        {
            throw new ArgumentException("root folder does not exist!");
        }
        MediaObjectFolder mof = new MediaObjectFolder(folder);
        IEnumerable<string> files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);
        foreach (string file in files)
        {
            MediaObject mo = new MediaObject(file);
            mof.MediaObjects.Add(mo);
        }
        lock (quelock)
        {
             // add object to global queue
             Enqueue(mof);
        }
    }
