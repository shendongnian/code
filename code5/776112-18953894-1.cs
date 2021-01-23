    string[] x = new[] { "10111", "10122", "10250", "10113" };
    var allSubstrings = new Dictionary<int, HashSet<string>>();
    for (int i = 0; i < x.Length; i++)
    {
        var substrings = new HashSet<string>();
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
            .OrderByDescending(g => g.Count())
            .ThenByDescending(g => g.Key.Length)
            .First().Key;
        for (int i = 0; i < x.Length; i++)
            x[i] = x[i].Replace(mostCommon, "");
    }
