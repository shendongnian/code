    if (!character.Moving) return; // Or just don't execute the rest of this code.
    character.position += character.speed * elapsedSeconds;
    character.timeToArrival -= elapsedSeconds;
    // Did the character arrive in a tile?
    if (character.timeToArrival <= 0)
    {
      // This will ensure the character is precisely in the tile, not a few pixels veered off.
      character.position = character.movingToTile.position; 
      if (character.Path.Count == 0)
      {
        character.Moving = false;
        // We are at final destination.
      }
      else
      {
        character.beginMovingToTarget(character.Path[0]);
        character.Path.RemoveAt(0);
      }
    }
