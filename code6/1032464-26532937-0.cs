    void Main() {
    	var teams = CreateTeams().ToArray();
    	int games = teams.Min(t => t.Games.Count);
    	var ordered = teams.OrderBy(team => 0);
    
    	for (int i = games - 1; i >= 0; i--) {
    		var captured = i; // the value of i will change, so use this capturing variable, 
    		ordered = ordered.ThenByDescending(team => team.Games[captured].Points);
    	}
    	ordered = ordered.ThenBy(team => team.Name);
    	
    	foreach (var team in ordered) {
    		Console.WriteLine("{0} {1}", team.Name, string.Join(", ", team.Games.Select(game => game.Points)));
    	}
    }
    
    IEnumerable<Team> CreateTeams() { 
    	yield return (new Team("War Donkeys", 1, 2, 3));
    	yield return (new Team("Fighting Beavers", 2, 2, 3));
    	yield return (new Team("Angry Potatoes", 2, 1, 3));
    	yield return (new Team("Wispy Waterfalls", 3, 2, 1));
    	yield return (new Team("Frisky Felines", 1, 2, 3));
    }
    
    class Team {
    	public string Name { get; set; }
    	public IList<Game> Games { get; set; }
    	
    	public Team(string name, params int[] points) {
    		this.Name = name;
    		this.Games = points.Select(p => new Game { Points = p }).ToArray();
    	}
    }
    
    class Game {
    	public int Points { get; set; }
    }
