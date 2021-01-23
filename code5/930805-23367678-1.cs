    Read(fileStream =>
    {
        var bytes = new byte[fileStream.Length];
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        var text = Encoding.Default.GetString(bytes);
        Console.WriteLine(text);
    }, @"C:\temp\test2.txt");
    static void Read(Action<FileStream> action, string path)
    {
        using (var fileStream = new FileStream(path, FileMode.Open))
        {
            action(fileStream);
        }
    }
