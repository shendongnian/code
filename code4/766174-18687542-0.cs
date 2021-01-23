    if (timer > TimeSpan.Zero)
    {
       timer -= gameTime.ElapsedGameTime;
       if (timer <= TimeSpan.Zero)
       {
           playerScore += 10;
           timer = TimeSpan.Zero;
       }
    }
