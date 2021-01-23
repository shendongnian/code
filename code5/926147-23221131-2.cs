    public static void Main(string[] args)
    {
        var extensions = new[] { "jpg", "jpeg", "bmp", "png", "gif" };
        var source = @"C:\Source";
        var destination = @"C:\Destination";
        var dump = @"C:\Dump";
        
        CopyFolder(source, destination, dump, extensions);
        
        Console.ReadLine();
    }
    
    public static void CopyFolder(
        string source,
        string destination,
        string dump,
        string[] extensionsForDestination
    )
    {
        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }
        if (!Directory.Exists(dump))
        {
            Directory.CreateDirectory(dump);
        }
        
        var directory = new DirectoryInfo(source);
        ProcessDirectory(directory, destination, dump, extensionsForDestination);
    }
    public static void ProcessDirectory(
        DirectoryInfo directory,
        string destination,
        string dump,
        string[] extensionsForDestination
    )
    {
        foreach (FileInfo file in directory.EnumerateFiles())
        {
            // Check if extension matches
            if(extensionsForDestination.Contains(file.Extension))
            {
                // Copy file to Destination
                file.CopyTo(destination);
            }
            else
            {
                // Copy file to Dump
                file.CopyTo(dump);
            }
        }
    }
