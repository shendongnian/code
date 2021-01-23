    public delegate void TimeUp(); // define delegate
    public TimeUp OnTimeUp { get; set; } // expose delegate
...
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        DateTime datetime = DateTime.Now;
        if (OnTimeUp != null) OnTimeUp(); // call delegate
    }
