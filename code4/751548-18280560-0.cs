    yourTimer.AutoReset = false;
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
         try
         {
         }
         finally
         {
             yourTimer.Enabled = true;// or yourTimer.Start();
         }
    }
