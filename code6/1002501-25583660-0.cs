    static readonly Regex RegExInstance = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);
    public string  ReplaceWithRegEx(string template, Dictionary<string, string> parameters)
    {
        return RegExInstance.Replace(template, match => GetNewValue(parameters, match));
    }
    private string GetNewValue(Dictionary<string, string> parameters, Match match)
    {
        var oldValue = match.Groups[1].Value;
        string newValue;
        var found = parameters.TryGetValue(oldValue, out newValue);
        if (found)
        {
            return newValue;
        }
        var originalValue = match.Groups[0].Value;
        return originalValue;
    }
