    yourTimer.AutoReset = false;
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
         try
         {
             // add your logic here
         }
         finally
         {
             yourTimer.Enabled = true;// or yourTimer.Start();
         }
    }
