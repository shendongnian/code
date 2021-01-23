    public static string Cleanup(string text, string[] exclude)
    {
        string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
        List<string> words = new List<string>();
    
        foreach(string part in parts)
        {
            if (!exclude.Contains(part))
            {
                words.Add(part);
            }
        }
    
        return string.Join(" ", words.ToArray());
    }
