    var allPaths = Directory.EnumerateFiles(folder, "*.txt")
        .SelectMany(path => File.ReadLines(path))
        .Select(line => { 
            string fileName = line;
            foreach (Char c in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(c.ToString(), "");
            return new{ line, path = Path.Combine(targetFolder, fileName) };
        } );
    foreach(var p in allPaths)
    {
        File.WriteAllText(p.path, p.line);
    }
