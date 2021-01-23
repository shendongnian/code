    if(ks.IsKeyDown(Keys.W))
     {
        if(!HasJumped)
        {
            VelocityY -= 15f;
            rectangle.Y -= 5;
            HasJumped = true;
        }
      }
      else
      {
         VelocityX = 0;  <---- Dont do this
      }
