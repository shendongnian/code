    var timer = new Timer(TimerTick, null, TimeSpan.Zero, new TimeSpan(0, 0, 0, 1));
    
    int lastMinute = 1;
    
    void TimerTick(object state)
    {
        var minute = DateTime.Now.Minutes;
        if (minute != lastMinute && minute % 5 == 0)
        {
            lastMinute = minute;
            //Check the .txt file
        }
    }
