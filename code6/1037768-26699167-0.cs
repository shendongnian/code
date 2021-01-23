    private void timer1_Tick(object sender, ElapsedEventArgs e)
            {
      if (counter[int.Parse(timers[t].ToString())] <= 0)
                    {
                        ReadyIndex = int.Parse(timers[t].ToString());
    
                       Invoke(new Action(() => {
                           this.Show();
                           this.WindowState = FormWindowState.Normal;
                           
                       }));
    
                        return;
                    }
    }
