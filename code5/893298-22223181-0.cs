    Timer = new Timer(DoWork, autoEvent, 0, Timeout.Infinite);//Prevent periodic timer
    void DoWork(object state)
    {
        //Do work and then set timer again
        timer.Change(TimeInMilliSeconds, Timeout.Infinite);
    }
