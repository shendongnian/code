    RemoteDirectoryInfo directory = session.ListDirectory("/home/martin/");
 
    foreach (RemoteFileInfo fileInfo in directory.Files)
    {
        string extension = Path.GetExtension(fileInfo.Name);
        if (string.Compare(extension, ".txt", true) == 0)
        {
            Console.WriteLine("Adding {0} to listing", fileInfo.Name);
        }
    }
