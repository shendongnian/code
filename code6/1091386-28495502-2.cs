    foreach (Collider collider in colliders.OrderBy(c => c.Position - player.Position))
    {
        // The tiles closest to the player should be at the start
        if (collider.Rectangle.Intersects(player.Rectangle))
        {
            // Do whatever you want to do here
            Break;
        }
    }
