      FallSpeed = 3;
      isTouchingGround = false;
      if(GrassList.Any(
          grass => grass.Rect.X - 32 <= Rect.X &&
                   grass.Rect.X + 32 >= Rect.X && 
                   grass.Rect.Y - 65 <= Rect.Y))
      {
         FallSpeed = 0;
         isTouchingGround = true;
      }
