    var files = Directory.GetFiles("path", "*", SearchOption.AllDirectories);
    var directories = Directory.GetDirectories("path","*", SearchOption.AllDirectories);
    private static void OnDeleted(object source, FileSystemEventArgs e)
    {
        if(files.Contains(e.FullPath))
        {
            // it's a file
        }
        else 
        {
           // it's a directory
        }
    }
