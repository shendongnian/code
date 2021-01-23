    string[] x = new[] { "10111", "10122", "10250", "10113" };
    var allSubstrings = new Dictionary<int, List<string>>();
    for (int i = 0; i < x.Length; i++)
    {
        var substrings = new List<string>();
        string str = x[i];
        for (int c = 0; c < str.Length - 1; c++)
        {
            for (int cc = 1; c + cc <= str.Length; cc++)
            {
                string substr = str.Substring(c, cc);
                if (allSubstrings.Count < 1 || allSubstrings[allSubstrings.Count - 1].Contains(substr))
                    substrings.Add(substr);
            }
        }
        allSubstrings.Add(i, substrings);
    }
    if (allSubstrings[allSubstrings.Count - 1].Count > 0)
    {
        string mostCommon = allSubstrings[allSubstrings.Count - 1]
            .GroupBy(str => str)
            .OrderByDescending(g => g.Key.Length)
            .ThenByDescending(g => g.Count())
            .First().Key;
        for (int i = 0; i < x.Length; i++)
            x[i] = x[i].Replace(mostCommon, "");
    }
