    public static string StripCrap(string input)
    {
        return input.Where(c => char.IsNumber(c) || c == '_' || c == '/' || 
                           c == '-').Aggregate("", (current, c) => current + c);
    }
