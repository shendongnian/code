        for (int p = 0; p < particle.Count; p++)
        {
	        for (int t = 0; t < Map.tiles.Count; t++)
	        {
	                 CheckCollitions(Map.tile[t], particle[p]);
        	}
        }
