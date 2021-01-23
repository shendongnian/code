    var lines = 20;
    foreach(string fullPath in searchResults)
    {
        List<string> allLines = new List<string>();
        allLines.Add(Path.GetFileNameWithoutExtension(fullPath));
        int currentLine = 0;
        foreach(string line in File.ReadLines(fullPath).Skip(10))
        {
            if(++currentLine > lines) break;
            allLines.Add(line);
        }
        while (currentLine++ < lines)
            allLines.Add(String.Empty);
        File.WriteAllLines(fullPath, allLines);
    }
