    public string[][] ProcessFile(string fileName)
    {
        var lines = File.ReadAllText(fileName).Split(new [] { Environment.NewLine }, 
            StringSplitOptions.RemoveEmptyEntries);
    
        // skip first line
        return lines.Skip(1).Select(line => line.Split(new[] {" "}, 
    		StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }
