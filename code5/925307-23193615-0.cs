    string text = File.ReadAllText("sample.txt");
    string[] items = Regex.Matches(text, "add .*?(?=\r\nadd|$)", RegexOptions.Singleline)
                          .Cast<Match>()
                          .Select(m => m.Value)
                          .ToArray();
    foreach (string item in items)
    {
        string line = Regex.Replace(item, @"\\\s*\r\n\s*", string.Empty);
        KeyValuePair<string, string>[] pairs = Regex.Matches(line, @"(?<name>\w+)=(?<value>.*?)(?=\w+=|$)")
                                                    .Cast<Match>()
                                                    .Select(m => new KeyValuePair<string, string>(m.Groups["name"].Value, m.Groups["value"].Value))
                                                    .ToArray();
    
        Console.WriteLine(line);
        foreach (var pair in pairs)
            Console.WriteLine("{0} = {1}", pair.Key, pair.Value);
    }
