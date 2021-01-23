    void Main()
    {
	string[] lines = System.IO.File.ReadAllLines(@"C:\temp\test.txt");
	var test = new List<string>();
	foreach (var line in lines)
	{
		if (!string.IsNullOrWhiteSpace(line))
		{
			var values = line.Split(':');
			test.Add(values[1].Trim());
		}
	}
	
	List<Game> games = new List<Game>();
	for (int i = 0;i < test.Count();i = i + 3)
	{
		Game game = new Game();	
		game.Name = test[i];
		game.Type = test[i+1];
		game.Difficulty = test[i+2];
		
		games.Add(game);
	}
	var rpgGames = games.Where(w => w.Type == "RPG");
    }
    class Game {
	public string Name {get;set;}
	public string Type {get;set;}
	public string Difficulty {get;set;}
    }
