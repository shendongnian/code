    foreach (var Chest in Chests) {
        if (Chest.Bounds.Intersects (Ship.Bounds)) {
            Player.Score += 1;
            Chest.IsActive = false;
        }
    }
    
    Chests.RemoveAll(c => !c.IsActive)
