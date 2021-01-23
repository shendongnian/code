        DateTime start = DateTime.MinValue;
        TimeSpan oldTime = TimeSpan.Parse("00:00:00");
        tm = new Timer();
        tm.Tick += new EventHandler(tm_Tick);
       
     void tm_Tick(object sender, EventArgs e)
                {
                    TimeSpan runTime = DateTime.Now - start;
                    lblTimer.Text = string.Format("{1:D2}:{2:D2}:{3:D2}",
                                                    runTime.Days,
                                                    runTime.Hours,
                                                    runTime.Minutes,
                                                    runTime.Seconds);
        
                }
