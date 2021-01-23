    //Inside Global.ascx 
          void Application_Start(object sender, EventArgs e) 
        {
          // Code that runs on application startup
         System.Timers.Timer myTimer = new System.Timers.Timer();
          // Set the Interval to 5 seconds (5000 milliseconds).
         myTimer.Interval = 5000;
         myTimer.AutoReset = true;
         myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
         myTimer.Enabled = true; 
         } 
     public void myTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
    {
         // use your mailer code 
        clsScheduleMail objScheduleMail = new clsScheduleMail();
        objScheduleMail.SendScheduleMail();   
    }
    // inside your class
    public void SendScheduleMail()
    { 
      // Write your send mail code here.
    } 
