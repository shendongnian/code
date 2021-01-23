    private List<string> GenerateFixtures(int teamCount, int matchCount)
    {
        var teams = new List<int>(Enumerable.Range(0, teamCount));
        var r = new Random();
        var matchups = from t1 in teams
                       from t2 in teams.Where(t => t > t1)
                       select new Tuple<int, int, int>(t1, t2, r.Next());
        var matches = matchups.OrderBy(m => m.Item3)
                              .Take(matchCount)
                              .Select(m => string.Format("{0} v {1}", m.Item1, m.Item2))
                              .ToList();
        return matches;
    }
