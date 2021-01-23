    public static Task DeleteAsync(string path)
    {
         Guard.FileExists(path);
    
         return Task.Run(() => { File.Delete(path); });
    }
    
    public static Task<FileStream> CreateAsync(string path)
    {
         Guard.IsNotNullOrWhitespace(path);
    
         return Task.Run(() => File.Create(path));
    }
    
    public static Task MoveAsync(string sourceFileName, string destFileName)
    {
         Guard.FileExists(sourceFileName);
         Guard.IsNotNullOrWhitespace(destFileName);
    
         return Task.Run(() => { File.Move(sourceFileName, destFileName); });
    }
