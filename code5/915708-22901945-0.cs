    string[] directories;
    
    try
    {
        directories = Directory.GetDirectories(path);
    }
    catch (Exception ex)
    {
       Console.Error.WriteLine(ex);
    }
    
    foreach (string subDir in directories)
    {
        queue.Enqueue(subDir);
    }
