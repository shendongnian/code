    public static string SafeTokenPosition(this string @string, int index)
    {
        if (string.IsNullOrEmpty(@string))
        {
            return string.Empty;
        }
    
        var tokens = @string.Split(new[] { " " }, 
                                   StringSplitOptions.RemoveEmptyEntries);
        return index >= tokens.Length ? string.Empty : tokens[index];
    }
    private static string ResolveLastName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return string.Empty;
        }
    
        var tokens = name.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    
        switch (tokens.Length)
        {
            case 2:
                return tokens[1];
            case 3:
                return tokens[2];
            default:
                return string.Empty;
        }
    }
    
    private static string ResolveMiddleName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return string.Empty;
        }
    
        var tokens = name.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    
        switch (tokens.Length)
        {
            // ex. John Pablo Kowalsky
            case 3:
                return tokens[1];
            default:
                return string.Empty;
        }
    }
    
    private static string ResolveFirstName(string name)
    {
        return SafeTokenPosition(name, 0);
    }
