    private static Task<bool> PutFile(FileStream source, string destRemoteFilename, bool overwrite)
    {
        if (string.IsNullOrWhiteSpace(destRemoteFilename))
            return Task.Factory.StartNew(() => false);
    
        var path = Path.GetDirectoryName(destRemoteFilename);
    
        if(path == null)
            return Task.Factory.StartNew(() => false);
    
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
    
        if (overwrite)
            if (!File.Exists(destRemoteFilename))
                return Task.Factory.StartNew(() => false);
            else
                File.Delete(destRemoteFilename);
    
        using (var dest = File.OpenWrite(destRemoteFilename))
        {
            source.Seek(0, SeekOrigin.Begin);
            return source.CopyToAsync(dest).ContinueWith(x => true);
        }
    }
