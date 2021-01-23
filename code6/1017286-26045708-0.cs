    Timer timer = new Timer();
    timer.Elapsed += timer_Elapsed;
    timer.Interval = TimeSpan.FromSeconds(60).TotalMiliseconds;
    bool processingSomething = false;
    
    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (!processingSomething)
        {
            processingSomething = true;
    
            // Process stuff here . . .
    
            processingSomething = false;
        }
    }
