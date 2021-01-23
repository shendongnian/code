    static void GetAllFiles(string path, IList<string> files)
    {
        try
        {
            Directory.GetFiles(path).ToList()
                .ForEach(f => files.Add(f));
    
            Directory.GetDirectories(path).ToList()
                .ForEach(f => GetAllFiles(f, files));
        }
        catch (UnauthorizedAccessException ex)
        {
           //Console.WriteLine(ex);
        }
    }
