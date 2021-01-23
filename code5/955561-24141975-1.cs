    if (File.Exists(filePath))
    {
        string status= string.Empty;
        using (var stream = new StreamReader(File.OpenRead(filePath)))
        {
            status = stream.ReadLine();
        }
        if (status != "SUCCEEDED")
        {
            File.Delete(filePath);
            createDb();
        }
    }
