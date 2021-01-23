        System.Timers.Timer timer1 = new System.Timers.Timer();
        timer1.Interval = 60000;//one minute
        timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
        timer1.Start();
            
        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
          lblRuntime.Text = string.Format(
               "Runtime [{0:dd\\:hh\\:mm\\:ss}]", stopWatch.Elapsed);
        }
