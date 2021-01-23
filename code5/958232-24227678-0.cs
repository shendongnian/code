    private System.Threading.Timer myTimer;
    private void SetTimerValue ()
    {
       
       DateTime requiredTime = DateTime.Today.AddHours(15).AddMinutes(00);
       if (DateTime.Now > requiredTime)
       {
          requiredTime = requiredTime.AddDays(1);
       }
     
       
       myTimer = new System.Threading.Timer(new TimerCallback(TimerAction));
       myTimer.Change((int)(requiredTime - DateTime.Now).TotalMilliseconds, Timeout.Infinite);
    }
     
    private void TimerAction(object e)
    {
       //here you can start your timer!!
    }
