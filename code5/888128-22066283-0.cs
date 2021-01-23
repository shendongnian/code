    System.Timers.Timer timer = new System.Timers.Timer();  
      
    timer.Elapsed += new ElapsedEventHandler(OnTimer);
    timer.Interval = 1000;
    timer.AutoReset = false;
    timer.Enabled = true;
    
    public void OnTimer(object sender, ElapsedEventArgs e)
    {
        // Do something
        // Update form
        Invoke((MethodInvoker)delegate() {
            UpdateForm();
        });
        // Restart timer
        ((System.Timers.Timer)sender).Start();
    }
    
    public void UpdateForm()
    {
       // Code to update the form
    }
