    System.Timers.Timer Delay = new System.Timers.Timer();
    Delay.Elapsed += new System.Timers.ElapsedEventHandler(Delay_Elapsed);
    Delay.Interval=Convert.ToInt32(milliseconds);
    Delay.Enabled = false;
    
     void Delay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
        Delay.Enabled = false; 
      }
    ......
    .....
    if (nextTimeRead > now) //Yes, so wait 7 minutes for files to be available
        {
            TimeSpan span = nextTimeRead.Subtract(now);
            Double milliseconds = span.TotalMilliseconds;
            Console.WriteLine("Sleep for milliseconds: " + milliseconds.ToString());
            Delay.Enabled = true;
            while (Delay.Enabled)
            {
              ////Wait until time passes
            }
            Console.WriteLine("Download files after sleep of: " + nextTimeRead.ToString());
            DownloadFilesByPeriod(nextTimeRead);
        }
