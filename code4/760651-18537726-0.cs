    for (int i = map.CollisionTiles.Count - 1; i >= 0; i--)
    {
        CollisionTile tile = map.CollisionTiles[i];
        if (!tile.isTransparant)
            player.Collision(tile.Rectangle, map.Width, map.Height);
        else
        {
            if (player.PickUp(tile, map.Width, map.Height))
                map.Remove(tile);
        }
        camera.Update(player.Position, map.Width, map.Height);
    }
        
