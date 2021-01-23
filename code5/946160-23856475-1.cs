    public static void Test()
    {
        string text = "Monday 11:30am,11 v 2,3 v 4";
        foreach (Match match in regex.Matches(text))
        {
            string team1Id = match.Groups[1].Value;
            string team1Name = teams.FirstOrDefault(t => t.Item1 == team1Id)
                                    .Item2;
            string team2Id = match.Groups[2].Value;
            string team2Name = teams.FirstOrDefault(t => t.Item1 == team2Id)
                                    .Item2;
            string fixtureWithNumbers = match.Groups[0].Value;
            string fixtureWithNames = team1Name + " v " + team2Name;
            text = text.Replace(fixtureWithNumbers, fixtureWithNames);
        }
        Console.WriteLine(text);
    }
