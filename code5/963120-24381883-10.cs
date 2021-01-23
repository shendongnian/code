       DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromMilliseconds(10);
            tmr.Tick += (snd,ee) =>
                {
            Save_click(null,null);
            tmr.Stop();
                };
            tmr.Start();
