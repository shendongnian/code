    void alarmTimer_Tick(object sender, EventArgs e)
    {
        alarmTimer.Stop();
        Console.Write("Wake up! it is {0}:{1} already! ", DateTime.Now.Hour, DateTime.Now.Minute);
    }
