    public string[] ProcessFile(string fileName)
    {
        var result = new List<string>();
        var lines = File.ReadAllText(fileName).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var line in lines)
        {
            result.AddRange(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }
    
        return result.ToArray();
    }
