    public string RemoveZeroes(string input)
    {
        if (!input.StartsWith("0"))
            return input;
        
        return RemoveZeroes(input.Remove(0, 1));
    }
