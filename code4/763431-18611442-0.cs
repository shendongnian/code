    private void SetUpTimer(TimeSpan alertTime)
    {
         DateTime current = DateTime.Now;
         TimeSpan timeToGo = alertTime - current.TimeOfDay;
         if (timeToGo < TimeSpan.Zero)
         {
            return;//time already passed
         }
         System.Threading.Timer timer = new System.Threading.Timer(x =>
         {
             this.SomeMethodRunsAt1600();
         }, null, timeToGo, Timeout.InfiniteTimeSpan);
    }
    private void SomeMethodRunsAt1600()
    {
        //this runs at 16:00:00
    }
