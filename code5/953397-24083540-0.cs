    protected void Page_Load(object sender, EventArgs e)
    {
         System.Timers.Timer timer = new System.Timers.Timer();
         timer.Interval = 500;
         timer.Elapsed += tm_Tick;
         timer.Enabled = true;
    }
    
    void tm_Tick(object sender, ElapsedEventArgs e)
        {
            MyClass.ShowPopup(div_main);
    
        }
