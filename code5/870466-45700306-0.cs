    private static bool delayFlag = false;
    private static double delayTime = 0;
    public static bool DelayGame(GameTime gameTime,int milliSeconds)
    {
      if(delayFlag)
      {
        if(gameTime.TotalGameTime.TotalMilliseconds >= delayTime)
        {
          delayFlag = false;
          return true;
        }
      }
      else
      {
        delayFlag = true;
        delayTime = gameTime.TotalGameTime.TotalMilliseconds + milliSeconds;
      }
      return false;
    }
