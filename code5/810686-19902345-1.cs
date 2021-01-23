    private bool enableFilter;
    public MainWindow()
    {
      InitializeComponent();
      timerfiltr.Tick += new EventHandler(timerfiltr_Tick);
      timerfiltr.Interval = new TimeSpan(0, 0, 0, 0, 400);
      
      acbIdentyfikatorPcS.GotFocus +=(s,e)=>{timerfiltr.Start();};
      acbIdentyfikatorPcS.LostFocus +=(s,e)=>{timerfiltr.Stop();};
      acbIdentyfikatorPcS.TextChanged +=（s,e）=>{enableFilter= true;};
    } 
    private void timerfiltr_Tick(object sender, EventArgs e)
    {
        if(enableFilter)
        {
            enableFilter= false;           
            //do filter
           
        }
    }
