    public static void ShowScores(string message, List<Player> players)
    {
        if (message != null) Console.WriteLine(message);
        foreach (var p in players.OrderByDescending(p => p.Score))
        {
            Console.WriteLine(" {0}: {1}", p.Name, p.Score);
        }
    }
