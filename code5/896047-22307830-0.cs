    const string sentence = "This  is a test   sentence.";
    MatchCollection matches = Regex.Matches(sentence, @"\s");
    foreach (Match match in matches)
    {
        Console.WriteLine("Space at character {0}", match.Index);
    }
