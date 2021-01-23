    public static bool check_smallint(string input)
    {
        if (String.IsNullOrWhiteSpace(input))
            return true;
    
        short value;
        return Int16.TryParse(input, value);
    }
 
