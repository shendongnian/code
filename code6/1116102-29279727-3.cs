    public Splash()
    {
      InitializeComponent();
      Timer timer = new Timer();
      timer.Interval = 5000;
      timer.Enabled = true;
      timer.Tick +=  (s,e) =>{ this.Close();};
    }
