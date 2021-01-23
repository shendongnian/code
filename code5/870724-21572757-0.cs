    void Main()
    {
        string input = "/api/lol/static-data/{region}/v1/champion/{id}";
        string output = ReplaceArguments(input, new
        {
            region = "Europe",
            id = 42
        });
        output.Dump();
    }
    
    public static string ReplaceArguments(string input, object arguments)
    {
        if (arguments == null || input == null)
            return input;
    
        var argumentsType = arguments.GetType();
        var re = new Regex(@"\{(?<name>[^}]+)\}");
        return re.Replace(input, match =>
        {
            var pi = argumentsType.GetProperty(match.Groups["name"].Value);
            if (pi == null)
                return match.Value;
    
            return (pi.GetValue(arguments) ?? string.Empty).ToString();
        });
    }
