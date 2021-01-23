        // May be null
        if telTimer!=null && telTimer.IsEnabled)
        {
           telTimer.Stop();
           return;
         }
         telTimer = new DispatcherTimer();
         telTimer.Tick += TelTimerTick;
         telTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
         telTimer.Start();
    }
    private void TelTimerTick(object sender, EventArgs e) //Every Tick
    {
        Data.Te(Td);
    }
