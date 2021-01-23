    private static async Task<bool> PutFile(FileStream source, string destRemoteFilename, bool overwrite)
    {
        if(string.IsNullOrWhiteSpace(destRemoteFilename))
            return false;
    
        var path = Path.GetDirectoryName(destRemoteFilename);
    
        if(path == null) 
            return false;
    
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
    
        if (overwrite)
            if (!File.Exists(destRemoteFilename))
                return false;
            else
                File.Delete(destRemoteFilename);
    
        using (var dest = File.OpenWrite(destRemoteFilename))
        {
            source.Seek(0, SeekOrigin.Begin);
            await source.CopyToAsync(dest);
    
            return true;
        }
    }
