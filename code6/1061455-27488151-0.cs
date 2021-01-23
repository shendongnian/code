    var extensions = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        { ".wma", ".mp3", ".wav" };
    var files = new DirectoryInfo(@"c:\").GetFiles()
                                         .Where(p => extensions.Contains(p.Extension));
    foreach (var file in files)
    {
        // try/catch if you really need, but I'd recommend catching a more
        // specific exception
        file.Attributes = FileAttributes.Normal;
        File.Delete(file.FullName);    
    }
                           
                              
