    public static void Test()
    {
        string text = "Monday 11:30am,11 v 2,3 v 4";
        foreach (Match match in regex.Matches(text))
        {
            // For the first team in the fixture:
            string team1Id = match.Groups[1].Value; // get the id from the text
            Team team1 = teams.FirstOrDefault(t => t.Item1 == team1Id); // look it up
            string team1Name = team1.Item2; // get the team name
            // For the second team in the fixture:
            string team2Id = match.Groups[2].Value; // get the id from the text
            Team team2 = teams.FirstOrDefault(t => t.Item1 == team1Id); // look it up
            string team2Name = team1.Item2; // get the team name
            // Replace the whole matched string (with numbers)...
            string fixtureWithNumbers = match.Groups[0].Value;
            // ... with the equivalent with team names.
            string fixtureWithNames = team1Name + " v " + team2Name;
            text = text.Replace(fixtureWithNumbers, fixtureWithNames);
        }
        Console.WriteLine(text);
    }
