    TimerForNotification.Stop();
    
    try
    {
     int count = new GetSMSNotifications().process();
    }
    catch (Exception ex)
    {
     // trace line here with ex.ToString().
    }
    
    TimerForNotification.Start();
    // trace line here stating, i started at DateTime.Now;
