    public delegate bool TryAgainAfterException(Exception ex);
    
    public void RepeatAction(Action action, TryAgainAfterException tryAgainFunction)
    {
       // set up whatever logic you would use for your do-while loop here
       bool tryAgain;
    
       do
       {
          tryAgain = false;
          try
          {
             action();
          }
          catch (Exception ex)
          {
             if (tryAgainFunction(ex))
             {
                // the specific logic of the Exception
                // handling would go here, including:
                tryAgain = true;
             }
             else
                throw ex;
          }
       }
       while (tryAgain);
    }
