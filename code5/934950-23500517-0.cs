    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        timer.Stop();
        if (elapsedTime > totalTime)
        {
            return;
        }
        else
        {
            // here I am performing the task, which starts at t=0 sec to t=10 sec
        }
        elapsedTime += interval;
        timer.Enabled = true; //Or timer.Start();
    }
