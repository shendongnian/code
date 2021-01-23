    public static string[] MyCustomSplit(string input, List<string> reservedWords)
    {
        List<string> output = new List<string>();
    
        string[] parts = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
        foreach (string part in parts)
        {
            if (!string.IsNullOrWhiteSpace(part))
            {
                string[] subParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
                List<string> subOutput = new List<string>();
    
                foreach (string supPart in subParts)
                {
                    if (!reservedWords.Contains(supPart))
                    {
                        subOutput.Add(supPart);
                    }
                }
    
                output.Add(string.Join(" ", subOutput.ToArray()));
            }
        }
    
        return output.ToArray();
    }
