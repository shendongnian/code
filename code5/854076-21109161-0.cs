    try
    {
        System.IO.FileAttributes attr = System.IO.File.GetAttributes(file);
    }
    catch(Exception ex)
    {
        files.add(file)
    }
