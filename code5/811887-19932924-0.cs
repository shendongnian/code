    string pattern = String.Join("|", keywords.Select(k => Regex.Escape(k)));
    Match m = Regex.Match(sentence, pattern, RegexOptions.IgnoreCase);
    
    if (m.Success)
    {
        Console.WriteLine("Keyword found: {0}", m.Value);
    }
    else
    {
        Console.WriteLine("No keywords found!");
    }
