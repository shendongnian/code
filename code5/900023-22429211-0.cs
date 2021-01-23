    string text = "MACRO(L\"TestA \\\"B\")";
    Match match = Regex.Match(text, "MACRO\\(L?\"(.*?)(?<!\\\\)\"\\)");
    if (match.Success)
    {
        Console.WriteLine(match.Groups[0].Value);
        Console.WriteLine(match.Groups[1].Value);
    }
