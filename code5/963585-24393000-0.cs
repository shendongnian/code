    // Test data representing what you pulled from the database in #1
    string file1Name = "Hello.txt";
    byte[] file1Data = Encoding.UTF8.GetBytes("Hello World");
    // Open a new .zip file
    using (FileStream stream = new FileStream(@"my.zip", FileMode.Create))
    using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Update))
    {
        // Add each item to the zip file. Loop this if you have multiple
        ZipArchiveEntry readmeEntry = archive.CreateEntry(file1Name);
        using (BinaryWriter writer = new BinaryWriter(readmeEntry.Open()))
        {
            writer.Write(file1Data);
        }
    }
