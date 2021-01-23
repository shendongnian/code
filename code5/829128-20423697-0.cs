    public void DispatcherTimerSetup(HttpClient httpClient, string lati, string longi, string UserId) 
    { 
         dispatcherTimer = new DispatcherTimer(); 
         dispatcherTimer.Tick += dispatcherTimer_Tick; 
         dispatcherTimer.Interval = new TimeSpan(0, 0, 1); 
         // TimeSpan for 1 Minute 0 secs 
         if (!dispatcherTimer.IsEnabled) 
         { 
              dispatcherTimer.Start(); 
         }
    }
    //Wrong return Type
    public int BackgroundService(string lati, string longi) {
        BackGroundService objBGServices = new BackGroundService();
        //Problem is Return Type
        return objBGServices.DispatcherTimerSetup(httpClient, lati, longi, UserId);
    }
    //See the Answer of **Jeroen Vannevel**
    public void BackgroundService(string lati, string longi) {
        BackGroundService objBGServices = new BackGroundService();
        objBGServices.DispatcherTimerSetup(httpClient, lati, longi, UserId);
    }
