    public static string RemoveMultiSpace(string input)
    {
        var firstPhase = Regex.Replace(input, @"\s(?=\s)", "");
        return Regex.Replace(firstPhase, @"(?<=[a-zA-Z])\s(?=[a-z])", "");
    }
