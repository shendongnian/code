		for (int p = 0; p < particle.Count; p++)
		{
			var tileWidth = 64;
			var tileHeight = 64;
			var particlePosition = particle[p].Position;
			var tx = particlePosition.X / tileWidth; 
			var ty = particlePosition.Y / tileHeight;
			var tile = tiles[tx, ty];
			if(tile == 0)
			{
				// no collision
			}
			else
			{
				// collision detected
			}
		}
