    public static List<string> ToDecimalAscii(string input)
    {
        var result = new List<string>();
            
        foreach (char c in input)
            result.Add(((int)c).ToString());
        return result;
    }
