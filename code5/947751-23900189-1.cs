    StringBuilder builder = new StringBuilder();
    builder.AppendLine("djdodjodo\t\t3893983");
    builder.AppendLine("dddfddffd\t\t233");
    builder.AppendLine("djdodjodo\t\t39838");
    builder.AppendLine("djdodjodo\t\t12");
    builder.AppendLine("djdodjodo\t\t444");
    builder.AppendLine("djdodjodo\t\t5683");
    builder.Append("djdodjodo\t\t33");
    
    // Replace this line with calling File.ReadAllText to read a file!
    string text = builder.ToString();
    
    MatchCollection matches = Regex.Matches(text, @"(\w+)[\s\t]+([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    // Here's the magic: we convert an IEnumerable<Match> into a dictionary!
    // Check that using regexps, int.Parse should never fail because
    // it matched numbers only!
    IDictionary<int, string> lines = matches.Cast<Match>()
                                        .ToDictionary(match => int.Parse(match.Groups[2].Value), match => match.Groups[1].Value);
    // Now you can access your lines as follows:
    string value = lines[33]; // <-- By value
