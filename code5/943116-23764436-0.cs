    var timer = new System.Timers.Timer((DateTime.Now - (DateTime.Now - TimeSpan.FromHours(DateTime.Now.Hour + 1))).Milliseconds);
    timer.Elapsed += (sender, evt) =>
    {
        timer.Interval = (DateTime.Now - (DateTime.Now - TimeSpan.FromHours(DateTime.Now.Hour + 1))).Milliseconds;
        // Do things
    };
    timer.Start();
				
