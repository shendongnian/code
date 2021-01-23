         List<Buoy> ChestsToRemove = new List<Buoy>();
         foreach (Buoy chest in Chests)
         {
            if (Buoy.Bounds.Intersects(Ship.Bounds))
            {
               Player.Score += 1;
               ChestsToRemove.Add(chest);
            }
         }
         foreach (Buoy num in ChestsToRemove)
         {
            Chests.Remove(num);
         }
