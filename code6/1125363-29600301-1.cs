    public string[] ProcessFile(string fileName)
    {
        var result = new List<string>();
        var lines = File.ReadAllText(fileName).Split(new [] { Environment.NewLine }, 
            StringSplitOptions.RemoveEmptyEntries);
    
        // skip the first 3 lines
        foreach (var line in lines.Skip(3))
        {
            result.AddRange(line.Split(new [] { " " }, 
                StringSplitOptions.RemoveEmptyEntries));
        }
    
        return result.ToArray();
    }
