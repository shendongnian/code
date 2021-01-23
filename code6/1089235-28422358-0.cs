    public void OpenGate(Action action)
    {
        try
        {
          MoveTheGate(true);
          action();
       }
       finally 
       {
        MoveTheGate(false);
       }
    }
