    //Make sure the current folder is empty, otherwise the folders are very likely to already exist.
    if (Directory.GetFiles(Directory.GetCurrentDirectory()).Any())
    {
        throw new IOException("Current directory is not empty.");
    }
    var source = File.ReadAllLines(@"C:\guids.txt");
    //Create the folders synchronoulsy to avoid race conditions.
    var batchCount = (source.Length/10000) + 1;
    for (int i = 0; i < batchCount; i++)
    {
        Directory.CreateDirectory(i.ToString());
    }
    source.AsParallel().ForAll(line =>
    {
        var folder = Array.IndexOf(source, line).ToString();
        var newFile = Path.Combine(folder.ToString(), line + ".txt");
        File.WriteAllText(newFile, "Some content");
    });
