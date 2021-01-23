    var tilesToRemove = new List<CollisionTiles>();
    foreach (var tile in map.CollisionTiles)
    {
        if (!tile.IsTransparent)
        {
            player.Collision(tile.Rectangle, map.Width, map.Height);
        }
        else if (player.PickUp(tile, map.Width, map.Height))
        {
            tilesToRemove.Add(tile);
        }
        camera.Update(player.Position, map.Width, map.Height);
    }
    // Remove all the ones we didn't want
    foreach (var tile in tilesToRemove)
    {
        map.Remove(tile);
    }
    // Potentially call camera.Update here? We don't know if it uses the tiles
