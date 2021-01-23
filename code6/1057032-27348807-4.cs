    private static void Main(string[] args)
    {
        // Of course this list could be generated from user input, and the scores
        // would start at 0, incrementing as play progressed. This is just for example.
        var players = new List<Player>
        {
            new Player {Name = "Abe", Score = 140},
            new Player {Name = "Bert", Score = 200},
            new Player {Name = "Charlie", Score = 150},
            new Player {Name = "Donald", Score = 300},
            new Player {Name = "Ernie", Score = 120},
        };
        var maxScore = players.Max(p => p.Score);
        var minScore = players.Min(p => p.Score);
        foreach (var player in players.Where(p => p.Score == maxScore))
        {
            // Note the inline check for a perfect score, which adds a '*' after it
            Console.WriteLine("Congratulations {0}, your score of {1}{2} was the highest.",
                player.Name, player.Score, maxScore == 300 ? "*" : "");
        }
        foreach (var player in players.Where(p => p.Score == minScore))
        {
            Console.WriteLine("{0}, your score of {1} was the lowest. " + 
                "Better get some practice.", player.Name, player.Score);
        }
        Console.WriteLine("The average score for this game was {0}.", 
            players.Average(p => p.Score));
    }
