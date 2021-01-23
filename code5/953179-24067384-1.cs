         List<Buoy> ChestsToRemove = new List<Buoy>();
         foreach (Buoy chest in Chests)
         {
            if (Buoy.Bounds.Intersects(Ship.Bounds))
            {
               Player.Score += 1;
               ChestsToRemove.Add(chest);
            }
         }
         foreach (Buoy chestToRemove in ChestsToRemove)
         {
            Chests.Remove(chestToRemove);
         }
