    String input = "-1-word-1-word-222-word-";
    String pattern = @"\A(-[0-9]+-word)+-\z";
    Match m = Regex.Match(input, pattern);
    if (m.Success) {
        Console.WriteLine(m.Groups[1].Captures.Count);
    }
