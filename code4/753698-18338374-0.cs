    System.Timers.Timer timer = new System.Timers.Timer(100);
    public void Initialize(object sender, EventArgs e)
    {
      timer.Elapsed+=Elapsed;
    }
    public void Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      //do stuff
    }
