    try
    {
        const string searchQuery = "*" + "keyword" + "*";
        const string folderName = @"C:\Folder";
        var directory = new DirectoryInfo(folderName);
        var directories = directory.GetDirectories(searchQuery, SearchOption.AllDirectories);
        var files = directory.GetFiles(searchQuery, SearchOption.AllDirectories);
        foreach (var d in directories)
        {
            Console.WriteLine(d);
        }
        foreach (var f in files)
        {
            Console.WriteLine(f);
        }
    }
    catch (Exception e)
    {
        //
    }
