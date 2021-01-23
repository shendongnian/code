            timer = new System.Timers.Timer(2 * 1000) { Enabled = true };
            timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e)
            {
            }
            
            timer.Start(); // finally, call the timer
