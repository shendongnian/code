    string tempPath = Path.GetTempFileName();
    using (var writer = new StreamWriter(tempPath))
    {
        foreach (string line in File.ReadLines(filePath))
        {
            writer.WriteLine(line);
            if (line.StartsWith("google"))
                writer.WriteLine("StackOverflow");
        }
        // If you want to add other lines to the end of the file, do it here:
        writer.WriteLine("This line will be at the end of the file.");
    }
    File.Delete(filePath);
    File.Move(tempPath, filePath); // Rename.
