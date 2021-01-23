    string tempPath = Path.GetTempFileName();
    using (var writer = new StreamWriter(tempPath))
    {
        foreach (string line in File.ReadLines(filePath))
        {
            writer.WriteLine(line);
            if (line.StartsWith("google"))
                writer.WriteLine("StackOverflow");
        }
    }
    File.Delete(filePath);
    File.Move(tempPath, filePath); // Rename.
