    static Dictionary<string, string> teamDb =
        teams.ToDictionary(t => t.Id, t => t.Name);
    public static void Test3(string text)
    {
        var result = Regex.Replace(text,
                                    @"((?<T>\d+)(?=\s*v))|((?<=v\s*)(?<T>\d+))",
                                    new MatchEvaluator(
                                        m => teamDb[m.Groups["T"].Value]
                                    ));
        Console.WriteLine("Test3: {0}", result);
    }
