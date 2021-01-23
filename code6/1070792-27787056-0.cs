    public static string GetData(string subjectLine)
    {
        var result = Regex.Match(subjectLine, @"\[\w{1, 10}-\d{1,}-\d{1,}\]");
        return result.Success ? result.Value : "Error";
    }
