    public static string[] MyCustomSplitAndCleanup(string input)
    {
        List<string> outputLines = new List<string>();
    
        string[] lines = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
                List<string> lineParts = new List<string>();
    
                for (int index = 0; index < parts.Length; index++ )
                {
                    string part = parts[index];
    
                    int numericValue = 0;
    
                    bool validPart = true;
    
                    if (int.TryParse(part, out numericValue))
                    {
                        if (index == 0 || index == parts.Length - 1)
                        {
                            validPart = false;
                        }
                    }
    
                    if (validPart)
                    {
                        lineParts.Add(part);
                    }
                }
    
                outputLines.Add(string.Join(" ", lineParts.ToArray()));
            }
        }
    
        return outputLines.ToArray();
    }
