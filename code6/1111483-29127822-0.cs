    public static string RemoveCharactersAfterFirstPeriod(string value)
    {
        if (!string.IsNullOrWhiteSpace(value) && value.Contains("."))
        {
            int index = value.IndexOf(".", StringComparison.OrdinalIgnoreCase);
            return value.Substring(0, index);
        }
            
        return value;
    }
