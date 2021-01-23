    private static string GetLastResponse(string message, string delimStartsWith, 
        string delimContains, string delimEndsWith, 
        StringComparison comparison = StringComparison.Ordinal)
    {
        if (string.IsNullOrWhiteSpace(message)) return message;
        
        var lastResponse = new StringBuilder();
        var lines = message.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None);
        foreach (var line in lines)
        {
            // Check to see if this line starts with, contains, 
            // and ends with the specified text
            if ((delimStartsWith == null || line.StartsWith(delimStartsWith, comparison)) &&
                (delimContains == null || line.IndexOf(delimContains, comparison) >= 0) &&
                (delimEndsWith == null ||line.EndsWith(delimEndsWith, comparison)))
            {
                // If we get here it means all our conditions were met, so this
                // line is a delimeter and we should break out of this loop.
                break;
            }
            // Haven't reached a delimeter yet, so add this line to our lastResponse
            lastResponse.AppendLine(line);
        }
        return lastResponse.ToString();
    }
