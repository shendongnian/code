    public delegate void autocheck();
    private System.Timers.Timer TTTimer = new System.Timers.Timer();
    
    public void autofilldgv()
    {
        if (this.InvokeRequired)
        {
          this.Invoke(new autocheck(UpdateControls));
        }
        else
        {
          UpdateControls();
        }
    }
    private void UpdateControls()
    {
       //call your method here
      filldgv();
    
    }
    void TTTimer_Elapsed(object sender System.Timers.ElapsedEventArgs e)
    {
      mymethod();
    }
    public void mymethod()
    {
      //this method is executed by the background worker
      autofilldgv();
    }
    private void frm_receptionView_Load(object sender, EventArgs e)
    {
      this.TTTimer.Interval = 1000; //1 sec interval
      this.TTTimer.Elapsed += new System.Timers.ElapsedEventHandler(TTTimer_Elapsed);
      this.TTTimer.Start();
    }
