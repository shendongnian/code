    for(int i = 0; i < numberOfPlayers; i++)
    {
        var player = new Player();
        player.Name = Console.ReadLine();
        player.Goals = Int32.Parse(Console.ReadLine());
        players.Add(player);
    }
