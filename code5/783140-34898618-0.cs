    private static double scheduledHour = 10;
    private static DateTime scheduledTime;
    
    public WinService()
    {
         scheduledTime = DateTime.Today.AddHours(scheduledHour);//setting 10 am of today as scheduled time- service start date
    }
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
          DateTime now = DateTime.Now;
          if (scheduledTime < DateTime.Now)
          {
             TimeSpan span = now - DateTime.Now;
             scheduledTime = scheduledTime.AddMilliseconds(span.Milliseconds).AddDays(1);// this will set scheduled time to 10 am of next day while correcting the milliseconds
             //do the scheduled task here
          }  
    }
