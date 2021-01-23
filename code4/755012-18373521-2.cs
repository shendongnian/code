    private static Task<T> RunOnCurrent<T>(Func<T> f)
    {
        var t = new Task<T>(f);
        t.Start(TaskScheduler.FromCurrentSynchronizationContext());
        return t;
    }
    
    private static Task<bool> PutFile(FileStream source, string destRemoteFilename, bool overwrite)
    {
        if (string.IsNullOrWhiteSpace(destRemoteFilename))
            return RunOnCurrent(() => false);
    
        var path = Path.GetDirectoryName(destRemoteFilename);
    
        if(path == null)
            return RunOnCurrent(() => false);
    
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
    
        if (overwrite)
            if (!File.Exists(destRemoteFilename))
                return RunOnCurrent(() => false);
            else
                File.Delete(destRemoteFilename);
    
        using (var dest = File.OpenWrite(destRemoteFilename))
        {
            source.Seek(0, SeekOrigin.Begin);
            return source.CopyToAsync(dest).ContinueWith(x => true);
        }
    }
