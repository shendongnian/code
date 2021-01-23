    private const string RegexIncludeBrackets = @"{{(?<Param>.*?)}}";
    
    public static string ParseString(string input)
    {
        return Regex.Replace(input, RegexIncludeBrackets, match =>
        {
            string cleanedString = match.Groups["Param"].Value.Replace(" ", String.Empty);
            switch (cleanedString)
            {
                case "Date":
                    return DateTime.Now.ToString("yyyy/MM/d");
                case "Time":
                    return DateTime.Now.ToString("HH:mm");
                case "DateTime":
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                default:
                    return match.Value;
            }
        });
    }
