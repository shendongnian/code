    aTimer = new System.Timers.Timer(1000); //One second, (use less to add precision, use more to consume less processor time
    int lastHour = DateTime.Now.Hour;
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if(lastHour < DateTime.Now.Hour || (lastHour == 23 && DateTime.Now.Hour == 0))
         {
               lastHour = DateTime.Now.Hour;
               YourImportantMethod(); // Call The method with your important staff..
         }
        
    }
