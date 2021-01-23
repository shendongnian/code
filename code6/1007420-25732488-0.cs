    var relatedFiles = Directory.EnumerateFiles(@"C:\Temp", "*.xml")
        .Where(path => Path.GetFileNameWithoutExtension(path).StartsWith("xrefTester_("));
    foreach(string path in relatedFiles)
    {
        string dir = Path.GetDirectoryName(path);
        string newFileName = string.Format("{0}{1}{2}", 
                    Path.GetFileNameWithoutExtension(path),
                    ".bak",
                    Path.GetExtension(path));
        System.IO.File.Move(path, Path.Combine(dir, newFileName));
    }
