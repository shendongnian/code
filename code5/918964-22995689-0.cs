     if (_timer == null)
     {
         _timer = new DispatcherTimer();
         _timer.Interval = TimeSpan.FromMilliseconds(1000);
     }
     _timer.Tick += (sender, e) =>
                {                                
                   Seconds--;
                };
