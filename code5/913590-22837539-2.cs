    public static string[] MyCustomSplit(string input, List<string> reservedWords)
    {
        List<string> outputLines = new List<string>();
    
        string[] lines = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
                List<string> lineParts = new List<string>();
    
                foreach (string part in parts)
                {
                    if (!reservedWords.Contains(part))
                    {
                        lineParts.Add(part);
                    }
                }
    
                outputLines.Add(string.Join(" ", lineParts.ToArray()));
            }
        }
    
        return outputLines.ToArray();
    }
