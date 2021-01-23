    IEnumerable<string> ParseText(string input)
    {
        var noQuotes = input.Replace("\"", "");
        return noQuotes.Split(',');
    }
