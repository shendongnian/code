    CrontabSchedule schedule = CrontabSchedule.Parse(pattern);
    DateTime nextOccurrence = this.schedule.GetNextOccurrence(DateTime.Now);
    
    TimeSpan interval = nextOccurrence.Subtract(now);
    
    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Interval = interval.TotalMilliseconds;
    
    timer.Elapsed -= this.OnScheduleTimerElapsed;
    timer.Elapsed += this.OnScheduleTimerElapsed;
    timer.Start();
