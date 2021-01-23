    Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Singleline);
    MatchCollection mc = regex.Matches(bibFileContent);
    List<String> results = new List<String>();
    foreach (Group m in mc[0].Groups)
    {
    results.Add(m.Value);
    }
