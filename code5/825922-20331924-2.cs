    TimerCallback callback = (state) =>
    {      
        var now = DateTime.Now; 
        if(now.DayOfWeek == DayOfWeek.Monday 
         && now.TimeOfDay.Hours == 17 && now.TimeOfDay.Minutes == 0)
        {
            MyMethod();
        }
    };
    Timer timer = new Timer(callback, application, 0, 10000);//10seconds
