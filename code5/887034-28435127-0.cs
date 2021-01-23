     protected override void OnStart(string[] args)
            {
              
                    _timer.Enabled = true;
    
                    DateTime currentTime = DateTime.Now;
                    int intervalToElapse = 0;
                    DateTime scheduleTime = Convert.ToDateTime(ConfigurationSettings.AppSettings["TimeToRun"]);
    
                    if (currentTime <= scheduleTime)
                        intervalToElapse = (int)scheduleTime.Subtract(currentTime).TotalSeconds;
                    else
                        intervalToElapse = (int)scheduleTime.AddDays(1).Subtract(currentTime).TotalSeconds;
    
                    _timer = new System.Timers.Timer(intervalToElapse * 1000);
                    _timer.AutoReset = true;
                    _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
                    _timer.Start();
            }
    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
            {
               //do your thing
    //set it to run on a 24-hour basis
         _timer.Interval = 60 * 60 * 24 * 1000;
    
    }
