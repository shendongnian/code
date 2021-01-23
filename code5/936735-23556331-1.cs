    var pattern = @"\(.+?\)";
    var match = Regex.Match(input, pattern, RegexOptions.RightToLeft);
    if (match.Success)
    {
        var result = input.Substring(0, match.Index);
        Console.WriteLine(result);
    }
    else
    {
        Console.WriteLine(input);
    }
