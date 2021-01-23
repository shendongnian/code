    public List<Player> GetSpectators(Hashset<Player> playersInGame, Coordinate coord)
    {
    	var playersInRange = new List<Player>();
    
    	// iterate through each player.
        foreach (var p in playersInGame)
    	{
    		// check if the tile they sitting on is in range of radius given.
    		if ((p.CurrentTile.X < coord.X + 6 || p.CurrentTile.X > coord.X - 6)
    			&&
    			(p.CurrentTile.Y < coord.Y + 6 || p.CurrentTile.Y > coord.Y - 6))
    		{
    			// Player is within radius.
    			playersInRange.Add(p);
    		}
    	}
    	
    	return playersInRange;
    }
