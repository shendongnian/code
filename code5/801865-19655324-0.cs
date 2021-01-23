    readonly Timer _timer = new Timer();
    
    void InitProgram()
    {    
        WriteToText("Welcome!");
      
       _timer.Interval = 3000;
       _timer.Tick += timer_Tick;
       _timer.Start();
    }
    
    void timer_Tick(object sender, EventArgs e)
    {
        WriteToText("How are you?"); // Continue
        StartTutorial();
    
        _timer.Stop();
    }
