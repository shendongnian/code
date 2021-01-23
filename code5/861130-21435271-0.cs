        public FijiLauncherControl()
        
        {        // timer set up
                        _logFileCheckTimer = new System.Timers.Timer(250);  
                        _logFileCheckTimer.Enabled = true;
                        _logFileCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(_logFileCheckTimer_Elapsed);
                       _logFileCheckTimer.Start();  // start the timer
         }    
    
         void _logFileCheckTimer_Elapsed(object sender, EventArgs e)
            {
                if (_processOn && IsLogOn)
                {
                    try
                    {
                        _processFinished = CheckStatuts();  // checking file status
    
                        if (_processFinished) // fire event if checking status returns true
                        {
                            OnIjmFinished(EventArgs.Empty);
                            _processOn = false;
                            _logFileCheckTimer.Stop();
                        }
                    }
                    catch (Exception ex)
                    {
    
                    }
                }
            }
