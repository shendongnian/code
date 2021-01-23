    public static List<Player> GetPlayers()
    {
        var players = GetPlayers(false);
        Console.WriteLine();
        players.AddRange(GetPlayers(true));            
        return players;
    }
	private static List<Player> GetPlayers(bool npcPlayers)
	{
		var players = new List<Player>();
		var playerType = npcPlayers ? "NPC" : "human";
		int numberOfPlayers = ConsoleHelper.GetIntFromUser(
			string.Format("How many {0} players will be playing? ", playerType),
			"<Invalid number>", (x) => x >= 0);
		for (int i = 1; i <= numberOfPlayers; i++)
		{
			string name;
			if (npcPlayers)
			{
				// Generate computer player names
				name = string.Format("ComputerPlayer{0}", i);
			}
			else
			{
				// Get human names from the user
				Console.Write("Enter the name for player #{0}: ", i);
				name = Console.ReadLine();
			}
			players.Add(new Player(name, npcPlayers));
		}
		return players;
	}
