    System.Timers.Timer readyUpTimer = new System.Timers.Timer(100);
    readyUpTimer.Elapsed -= readyUpTimer_Elapsed;
    readyUpTimer.Elapsed += readyUpTimer_Elapsed;
    DateTime readyUpInitialised = DateTime.Now;
    readyUpTimer.Start();
   
