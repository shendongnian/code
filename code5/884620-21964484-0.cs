    using System.Timers;
     
    Timer tmrExecutor = new Timer();
     
    protected override void OnStart(string[] args)
    {
          tmrExecutor.Elapsed += new ElapsedEventHandler(tmrExecutor_Elapsed); // adding Event
          tmrExecutor.Interval = 15000; // Set your time here 
          tmrExecutor.Enabled = true;
          tmrExecutor.Start();
    }
     
    private void tmrExecutor_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
          //call your web-service here
    }
     
    protected override void OnStop()
    {
          tmrExecutor.Enabled = false;
    }
