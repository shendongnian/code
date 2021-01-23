        var lines =  File.ReadLines("test.txt");
        var games = new List<Game>();
        
        var currGame = new Game();
        foreach (string line in lines)
        {
            var parts = line.Split(':');
            if (parts.Length == 1)
            {
                games.Add(currGame);
                currGame = new Game();
            }
            else if (parts[0].EndsWith("Name"))
                currGame.Name = parts[1].Trim();
            else if (parts[0].EndsWith("Type"))
                currGame.Type = parts[1].Trim();
            else
                currGame.Difficulty = parts[1].Trim();
        }
        
        var output = string.Join(System.Environment.NewLine, games.Where(x => x.Type == "RPG")
            .Select(x => string.Format("{0} [{1}] => Difficulty: {2}", x.Name, x.Type, x.Difficulty))
            .ToArray());
        Console.Write(output);
