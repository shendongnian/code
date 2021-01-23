        var best = playerStats.MaxBy(x => x.Goals);
        Console.WriteLine("The top player is {0} with a score of {1}",
                          best.Name, best.Goals);
        public class PlayerStats
        {
            public string Name { get; set; }
            public int Goals { get; set; }
        }
