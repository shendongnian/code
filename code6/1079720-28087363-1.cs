    if (File.Exists(nFile))
    {
        Console.WriteLine("File already exists!");
        ...
    }
    // continue creating new file and inserting data to it
    try
    {
        fs = new FileStream(nFile, FileMode.CreateNew, FileAccess.ReadWrite);
        ...
    }
