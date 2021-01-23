    private bool enabledChanged;
    private double startTime;
    ...
    protected void Update(GameTime gameTime)
    {
         if (enabledChanged) //If we should start moving
         {
              enabledChanged = false;
              startTime = gameTime.TotalGameTime.TotalSeconds;
         }
         if (gameTime.ElapsedGameTime.TotalSeconds <= startTime + 3) //If time is less than start time, plus 3 seconds, move
         {
              //Move object
         }
    }
